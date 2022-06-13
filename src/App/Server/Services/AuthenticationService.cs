namespace Azox.XTradeBot.App.Server.Services
{
    using Azox.XTradeBot.App.Server.Configs;
    using Azox.XTradeBot.App.Shared.Models;
    using Azox.XTradeBot.App.Shared.Services;
    using Azox.XTradeBot.Services;
    using Azox.XTradeBot.Services.Models;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    internal class AuthenticationService :
        IAuthenticationService
    {
        #region Fields

        private readonly ISystemUserService _systemUserService;
        private readonly JwtConfig _jwtConfig;
        #endregion Fields

        #region Ctor

        public AuthenticationService(
            ISystemUserService systemUserService,
            JwtConfig jwtConfig)
        {
            _systemUserService = systemUserService;
            _jwtConfig = jwtConfig;
        }

        #endregion Ctor

        #region Utilities

        private string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            ClaimsIdentity identity = new(claims, "xtrade-auth");

            SymmetricSecurityKey securityKey = new(_jwtConfig.SecretKeyBytes);
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        #endregion Utilities

        #region Methods

        public async Task<LoginResponse> LoginAsync(LoginRequest request, ProtoBuf.Grpc.CallContext callContext = default)
        {
            SystemUserLoginResult loginResult = await _systemUserService
                .LoginCheckAsync(request.Username, request.Password);

            if (loginResult.Result == SystemUserLoginCheckResult.Succeeded)
            {
                return new LoginResponse
                {
                    Success = true,
                    Token = GenerateJwtToken(loginResult.Claims)
                };
            }
            else
            {
                return new LoginResponse
                {
                    Success = false,
                    ErrMessage = ""
                };
            }
        }

        public async Task<LoginResponse> LoginWithTokenAsync(LoginRequest request, ProtoBuf.Grpc.CallContext callContext = default)
        {
            LoginResponse response = new();
            try
            {
                SymmetricSecurityKey securityKey = new(_jwtConfig.SecretKeyBytes);
                TokenValidationParameters validationParameters = new()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = securityKey,
                };
                JwtSecurityTokenHandler tokenHandler = new();

                ClaimsPrincipal principal = tokenHandler.ValidateToken(
                    request.Token,
                    validationParameters,
                    out SecurityToken validationToken);

                if (validationToken is JwtSecurityToken jwtSecurityToken)
                {
                    if (jwtSecurityToken != null
                        && jwtSecurityToken.ValidTo > DateTime.Now
                        && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    {
                        response.Success = true;
                        response.Username = principal.Identity.Name;
                        response.Token = GenerateJwtToken(principal.Claims);
                        response.RoleLevel = (RoleLevel)Convert.ToInt32(principal.FindFirst(ClaimTypes.Role).Value);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrMessage = ex.Message;
            }

            return await Task.FromResult(response);
        }

        #endregion Methods
    }
}
