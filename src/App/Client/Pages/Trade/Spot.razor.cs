namespace Azox.XTradeBot.App.Client.Pages.Trade
{
    using Azox.XTradeBot.App.Client.Components;
    using Azox.XTradeBot.App.Shared.Services;

    using Microsoft.AspNetCore.Components;

    using System.Threading.Tasks;

    public partial class Spot
    {
        #region Fields

        private PairSelect _pairSelect;

        #endregion Fields

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            var pairs = await TradePageService.GetPairs();

            await _pairSelect.SetParametersAsync(ParameterView.FromDictionary(
                new Dictionary<string, object?>()
                {
                    { nameof(PairSelect.Pairs), pairs }
                }));
        }

        #endregion Methods

        #region Properties

        [Inject]
        ITradePageService TradePageService { get; set; }

        #endregion Properties
    }
}
