namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public class Exchange :
        DeletableBasicEntityBase
    {
        #region Ctor

        protected Exchange() { }

        protected internal Exchange(
            string code,
            string name,
            string description) :
            base(code, name, description)
        {
            Extended = new();
            Pairs = new List<ExchangePair>();
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual ExchangeExtended Extended { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<ExchangePair> Pairs { get; private set; }

        #endregion Properties
    }
}
