namespace Azox.AMQP
{
    using Azox.AMQP.Configs;
    using Azox.AMQP.Models;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System.Text;

    internal class AmqpService :
        IAmqpService
    {
        #region Fields

        private readonly IConnection _connection;

        #endregion Fields

        #region Ctor

        public AmqpService(AmqpConfig amqpConfig)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                Endpoint = new(amqpConfig.HostName),
                UserName = amqpConfig.Username,
                Password = amqpConfig.Password,
                VirtualHost = amqpConfig.VirtualHost
            };

            if (amqpConfig.Port.HasValue)
            {
                connectionFactory.Endpoint.Port = amqpConfig.Port.Value;
            }

            _connection = connectionFactory.CreateConnection();
        }

        #endregion Ctor

        #region Methods

        public void Consume<T>(ConsumeRequest request, Action<T> onReceived)
        {
            Thread consumeThread = new Thread(() =>
            {
                IModel consumeModel = _connection.CreateModel();

                    consumeModel.ExchangeDeclare(
                        request.ExchangeName,
                        request.ExchangeType);

                string queueName = consumeModel.QueueDeclare();
                consumeModel.QueueBind(queueName, request.ExchangeName, request.RoutingKey);

                EventingBasicConsumer consumer = new(consumeModel);
                consumer.Received += (s, e) =>
                {
                    if (!request.CancellationToken.IsCancellationRequested)
                    {
                        string messageContent = Encoding.UTF8.GetString(e.Body.ToArray());
                        T message = JsonConvert.DeserializeObject<T>(messageContent);

                        onReceived?.Invoke(message);
                    }
                };

                consumeModel.BasicConsume(queueName, true, consumer);
            });

            consumeThread.Start();
        }

        #endregion Methods
    }
}
