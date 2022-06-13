namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public class SystemUserExchange :
        DeletableTrackableEntityBase
    {
        #region Ctor

        protected SystemUserExchange() { }

        protected internal SystemUserExchange(
            SystemUser user,
            Exchange exchange,
            string apiKey,
            string apiSecretKey)
        {
            User = user;
            Exchange = exchange;
            ApiKey = apiKey;
            ApiSecretKey = apiSecretKey;

            Currencies = new List<SystemUserCurrency>();
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual SystemUser? User { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Exchange? Exchange { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ApiKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ApiSecretKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<SystemUserCurrency> Currencies { get; private set; }

        #endregion Properties
    }
}