namespace Azox.Core.Eventing
{
    using Azox.Core.Reflection;

    using System;
    using System.Collections.Generic;

    internal sealed class EventContext :
        IEventContext
    {
        #region Fields

        private readonly Dictionary<string, List<IEvent>> _events;

        #endregion Fields

        #region Ctor

        public EventContext(IServiceProvider serviceProvider)
        {
            _events = new();

            foreach (Type eventInterfaceType in TypeFinder.FindInterfacesOf<IEvent>())
            {
                foreach (Type eventType in TypeFinder.FindClassesOf(eventInterfaceType))
                {
                    try
                    {
                        IEvent @event = (IEvent)Activator.CreateInstance(eventType, new[] { serviceProvider });
                        if (!_events.ContainsKey(eventType.FullName))
                        {
                            _events[eventType.FullName] = new List<IEvent>();
                        }
                        _events[eventType.FullName].Add(@event);
                    }
                    catch (Exception ex)
                    {
                        throw new AzoxBugException(ex.Message);
                    }
                }
            }
        }

        #endregion Ctor

        #region Methods

        public void Invoke<TEvent>(object obj)
            where TEvent : IEvent
        {
            string eventTypeName = typeof(TEvent).FullName;
            if (_events.TryGetValue(eventTypeName, out List<IEvent> events))
            {
                events.ForEach(x => x.Invoke(obj));
            }
        }

        public async Task InvokeAsync<TEvent>(object obj, CancellationToken cancellationToken = default)
            where TEvent : IEvent
        {
            string eventTypeName = typeof(TEvent).FullName;
            if (_events.TryGetValue(eventTypeName, out List<IEvent> events))
            {
                foreach (IEvent @event in events)
                {
                    await @event.InvokeAsync(obj, cancellationToken);
                }
            }
        }

        #endregion Methods
    }
}
