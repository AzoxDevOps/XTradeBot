namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;

    /// <summary>
    /// 
    /// </summary>
    public class SystemUserGroup :
        DeletableBasicEntityBase
    {
        #region Ctor

        protected SystemUserGroup() { }

        protected internal SystemUserGroup(
            SystemUserGroupLevel level,
            string code,
            string name,
            string description) :
            base(code, name, description)
        {
            Level = level;
            Memberships = new List<SystemUser>();
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public virtual SystemUserGroupLevel Level { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<SystemUser> Memberships { get; private set; }

        #endregion Properties
    }
}
