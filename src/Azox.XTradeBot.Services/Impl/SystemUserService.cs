namespace Azox.XTradeBot.Services
{
    using Azox.Core.Extensions;
    using Azox.Data;
    using Azox.Services;
    using Azox.XTradeBot.DomainModel;
    using Azox.XTradeBot.Services.Models;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;

    internal class SystemUserService :
        EntityServiceBase<SystemUser>,
        ISystemUserService
    {
        #region Ctor

        public SystemUserService(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        #endregion Ctor

        #region Utilities

        private (string PasswordSalt, string PasswordHash) GeneratePasswordHash(string password)
        {
            byte[] passwordSaltBytes = RandomNumberGenerator.GetBytes(16);
            string passwordSalt = Convert.ToBase64String(passwordSaltBytes);

            return (passwordSalt, GeneratePasswordHash(password, passwordSalt));
        }

        private string GeneratePasswordHash(string password, string passwordSalt)
        {
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            byte[] passwordSaltBytes = Convert.FromBase64String(passwordSalt);
            byte[] buffer = new byte[passwordBytes.Length + passwordSaltBytes.Length];

            Buffer.BlockCopy(passwordSaltBytes, 0, buffer, 0, passwordSaltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, buffer, passwordSaltBytes.Length, passwordBytes.Length);

            byte[] passwordHashBytes;
            using (SHA1 sha1 = SHA1.Create())
            {
                passwordHashBytes = sha1.ComputeHash(buffer);
            }

            return Convert.ToBase64String(passwordHashBytes);
        }

        #endregion Utilities

        #region Methods

        public virtual async Task<SystemUser> GetByUsernameAsync(string username)
        {
            return await SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<SystemUserLoginResult> LoginCheckAsync(string username, string password)
        {
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return new SystemUserLoginResult
                {
                    Result = SystemUserLoginCheckResult.InvalidUsernameOrPassword
                };
            }

            username = username.Trim().ToLowerInvariant();

            SystemUser systemUser = await GetByUsernameAsync(username);

            if (systemUser == null)
            {
                return new SystemUserLoginResult
                {
                    Result = SystemUserLoginCheckResult.InvalidUsernameOrPassword
                };
            }

            if (!systemUser.IsActive)
            {
                return new SystemUserLoginResult
                {
                    Result = SystemUserLoginCheckResult.InactiveUser
                };
            }

            if (systemUser.IsLocked)
            {
                return new SystemUserLoginResult
                {
                    Result = SystemUserLoginCheckResult.LockedUser
                };
            }

            if (systemUser.PasswordHashed)
            {
                string passwordHash = GeneratePasswordHash(password, systemUser.PasswordSalt);

                if (systemUser.PasswordHash != passwordHash)
                {
                    AuthenticationSettings _authenticationSettings = new();

                    bool locked = systemUser.RecordFailedLoginAttempt(_authenticationSettings.MaxInvalidPasswordAttempts);

                    UnitOfWork.GetRepository<SystemUser>().Update(systemUser);

                    return new SystemUserLoginResult
                    {
                        Result = SystemUserLoginCheckResult.InvalidUsernameOrPassword
                    };
                }
            }
            else
            {
                (string PasswordSalt, string PasswordHash) = GeneratePasswordHash(password);
                systemUser.SetPassword(PasswordSalt, PasswordHash);
            }

            systemUser.RecordSuccessfulLoginAttempt();
            UnitOfWork.GetRepository<SystemUser>().Update(systemUser);

            UnitOfWork.SaveChanges();

            return new SystemUserLoginResult
            {
                Result = SystemUserLoginCheckResult.Succeeded,
                Claims = new()
                {
                    new Claim(
                        ClaimTypes.Name,
                        systemUser.Username,
                        ClaimValueTypes.Email),
                    new Claim(
                        ClaimTypes.NameIdentifier,
                        systemUser.Id.ToString(),
                        ClaimValueTypes.Integer),
                    new Claim(
                        ClaimTypes.Role,
                        systemUser.UserGroup.Level.ToString("D"),
                        ClaimValueTypes.Integer)
                }
            };
        }

        public async Task<SystemUserRegistrationResult> RegisterAsync(string username, string password)
        {
            if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return SystemUserRegistrationResult.InvalidUsernameOrPassword;
            }

            username = username.Trim().ToLowerInvariant();

            AuthenticationSettings _authenticationSettings = new();

            if (Any(x => x.Username == username))
            {
                return SystemUserRegistrationResult.UserExists;
            }

            if (password.Length < _authenticationSettings.GetMinRequiredPasswordLength())
            {
                return SystemUserRegistrationResult.InvalidUsernameOrPassword;
            }

            if (_authenticationSettings.PasswordComplexityEnforced)
            {
                int complexityLevel = 0;

                if (password.Any(x => char.IsLower(x)))
                {
                    complexityLevel++;
                }

                if (password.Any(x => char.IsUpper(x)))
                {
                    complexityLevel++;
                }

                if (password.Any(x => char.IsDigit(x)))
                {
                    complexityLevel++;
                }

                if (password.Any(x => char.IsPunctuation(x) || char.IsSymbol(x)))
                {
                    complexityLevel++;
                }

                if (complexityLevel < _authenticationSettings.MinComplexityLevel)
                {
                    return SystemUserRegistrationResult.InvalidUsernameOrPassword;
                }
            }

            (string PasswordSalt, string PasswordHash) = GeneratePasswordHash(password);
            SystemUserGroup systemUserGroup = await UnitOfWork.GetRepository<SystemUserGroup>()
                .SingleOrDefaultAsync(x => x.Level == SystemUserGroupLevel.Level1);

            SystemUser systemUser = new(systemUserGroup, username, PasswordHash, PasswordSalt);

            await UnitOfWork.GetRepository<SystemUser>().InsertAsync(systemUser);
            await UnitOfWork.SaveChangesAsync();
            return SystemUserRegistrationResult.Succeeded;
        }

        #endregion Methods

        #region Nested Classes

        private struct AuthenticationSettings
        {
            #region Ctor

            public AuthenticationSettings()
            {
                MaxInvalidPasswordAttempts = 3;
                MinComplexityLevel = 3;
                MinRequiredPasswordLength = 8;
                PasswordComplexityEnforced = true;
            }

            #endregion Ctor

            #region Methods

            public int GetMinRequiredPasswordLength()
            {
                if (PasswordComplexityEnforced)
                {
                    return Math.Max(8, MinRequiredPasswordLength);
                }

                return MinRequiredPasswordLength;
            }

            #endregion Methods

            #region Properties

            /// <summary>
            /// 
            /// </summary>
            public int MaxInvalidPasswordAttempts { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int MinComplexityLevel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int MinRequiredPasswordLength { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public bool PasswordComplexityEnforced { get; set; }

            #endregion Properties
        }

        #endregion Nested Classes
    }
}
