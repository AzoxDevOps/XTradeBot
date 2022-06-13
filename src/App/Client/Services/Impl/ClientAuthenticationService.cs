namespace Azox.XTradeBot.App.Client.Services
{
    using Azox.XTradeBot.App.Shared.Models;
    using Azox.XTradeBot.App.Shared.Services;
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Security.Claims;
    using System.Threading.Tasks;

    internal class ClientAuthenticationService :
        AuthenticationStateProvider,
        IClientAuthenticationService
    {
        #region Fields

        private const string TOKEN_KEY = "xtrade-token";

        private readonly IAuthenticationService _authenticationService;
        private readonly ILocalStorageService _localStorageService;

        #endregion Fields

        #region Ctor

        public ClientAuthenticationService(
            IAuthenticationService authenticationService,
            ILocalStorageService localStorageService)
        {
            _authenticationService = authenticationService;
            _localStorageService = localStorageService;
        }

        #endregion Ctor

        #region Utilities

        private AuthenticationState Anonymous()
        {
            ClaimsIdentity claimsIdentity = new();
            ClaimsPrincipal principal = new(claimsIdentity);
            return new AuthenticationState(principal);
        }

        #endregion Utilities

        #region Methods

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorageService.GetItem(TOKEN_KEY);
            if (string.IsNullOrEmpty(token))
            {
                return Anonymous();
            }

            LoginResponse loginResponse = await _authenticationService
                .LoginWithTokenAsync(new LoginRequest { Token = token });

            if (!loginResponse.Success)
            {
                return Anonymous();
            }

            await _localStorageService.SetItem(TOKEN_KEY, loginResponse.Token);

            ClaimsIdentity identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name,loginResponse.Username,ClaimValueTypes.Email),
                new Claim(ClaimTypes.Role,loginResponse.RoleLevel.ToString(),ClaimValueTypes.Integer)
            }, "xtrade-auth");

            ClaimsPrincipal principal = new(identity);

            return new AuthenticationState(principal);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            LoginResponse response = await _authenticationService
                .LoginAsync(loginRequest);

            if (response.Success)
            {
                await _localStorageService.SetItem(TOKEN_KEY, response.Token);
            }

            return response;
        }

        #endregion Methods
    }
}
