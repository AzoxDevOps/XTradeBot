namespace Azox.XTradeBot.App.Client.Pages
{
    using Azox.XTradeBot.App.Client.Services;
    using Azox.XTradeBot.App.Shared.Models;
    using Microsoft.AspNetCore.Components;

    public partial class Login
    {
        #region Inject

        [Inject]
        IClientAuthenticationService AuthenticationService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        #endregion Inject

        #region Methods

        protected override void OnInitialized()
        {
            Model = new();
            base.OnInitialized();
        }

        private async Task LoginAsync()
        {
            LoginButtonIsBusy = !LoginButtonIsBusy;

            LoginResponse loginResponse = await AuthenticationService.LoginAsync(Model);
            if (loginResponse.Success)
            {
                NavigationManager.NavigateTo("/", true);
            }

            LoginButtonIsBusy = !LoginButtonIsBusy;
        }

        #endregion Methods

        #region Properties

        public LoginRequest Model { get; set; }

        public bool LoginButtonIsBusy { get; set; }

        #endregion Properties
    }
}
