namespace Azox.XTradeBot.DomainModel
{
    using Azox.DomainModel;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class SystemUser :
        DeletableTrackableEntityBase
    {
        #region Ctor

        protected SystemUser() { }

        protected internal SystemUser(
            SystemUserGroup userGroup,
            string username,
            string passwordHash,
            string passwordSalt)
        {
            UserGroup = userGroup;
            Username = username;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;

            IsActive = true;
            IsLocked = false;

            Exchanges = new List<SystemUserExchange>();
            Extended = new();
        }

        #endregion Ctor

        #region Utilities

        private void Lock()
        {
            IsLocked = true;
            LastLockTime = DateTime.UtcNow;
        }

        #endregion Utilities

        #region Methods

        protected internal virtual bool RecordFailedLoginAttempt(int maxInvalidPasswordAttempts)
        {
            if (++FailedLoginAttemptCount >= maxInvalidPasswordAttempts)
            {
                Lock();
                return true;
            }

            return false;
        }

        protected internal virtual void RecordSuccessfulLoginAttempt()
        {
            FailedLoginAttemptCount = 0;
            LastLoginTime = DateTime.UtcNow;

            Unlock();
        }

        protected internal virtual void SetPassword(string passwordSalt, string passwordHash)
        {
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            PasswordHashed = false;

            LastUpdatedTime = DateTime.UtcNow;
        }

        protected internal virtual void Unlock()
        {
            IsLocked = false;
            FailedLoginAttemptCount = 0;
        }

        #endregion Methods

        #region Properties

        public virtual SystemUserGroup? UserGroup { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Username { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PasswordHash { get; protected internal set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string PasswordSalt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool PasswordHashed { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsActive { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsLocked { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int FailedLoginAttemptCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastLockTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastLoginTime { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string? FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// 
        /// </summary>
        public virtual SystemUserExtended Extended { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IEnumerable<SystemUserExchange> Exchanges { get; private set; }

        #endregion Properties
    }
}
