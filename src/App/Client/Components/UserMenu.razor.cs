namespace Azox.XTradeBot.App.Client.Components
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class UserMenu
    {
        #region Methods

        private async Task OffcanvasOnClick(string path)
        {
            await Task.CompletedTask;
        }

        private async Task Logout()
        {
            Navigation.NavigateTo(Navigation.Uri, true);
            await Task.CompletedTask;
        }

        #endregion Methods

        #region Properties

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public bool OffCanvas { get; set; }

        #endregion Properties
    }
}
