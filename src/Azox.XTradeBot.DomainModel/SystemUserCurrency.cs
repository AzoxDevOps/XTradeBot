namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public class SystemUserCurrency :
        DeletableTrackableEntityBase
    {
        #region Fields

        protected SystemUserCurrency() { }

        protected internal SystemUserCurrency(
            SystemUserExchange systemUserExchange,
            Currency currency)
        {
            UserExchange = systemUserExchange;
            Currency = currency;

            Available = decimal.Zero;
            Locked = decimal.Zero;
            SoftLocked = decimal.Zero;
        }

        #endregion Fields

        #region Methods

        protected internal virtual void SetBalance(decimal available, decimal locked)
        {
            Available = available;
            Locked = locked;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual SystemUserExchange? UserExchange { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Currency? Currency { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal Available { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal Locked { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual decimal SoftLocked { get; private set; }

        #endregion Properties
    }
}