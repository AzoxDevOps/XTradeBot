namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public class Currency :
        DeletableBasicEntityBase
    {
        #region Ctor

        protected Currency() { }

        protected internal Currency(
            string code,
            string name,
            string description) :
            base(code, name, description)
        {
            Extended = new();
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual CurrencyExtended Extended { get; protected internal set; }

        #endregion Properties
    }
}
