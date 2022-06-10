namespace Azox.XTradeBot.App.Client.Components
{
    using Azox.XTradeBot.App.Shared.Models;
    using Azox.XTradeBot.App.Shared.Services;

    using Microsoft.AspNetCore.Components;

    public partial class PairSelect
    {
        #region Fields

        private ExchangePairModel? _selectedPair;

        #endregion Fields

        #region Utilities

        #endregion Utilities

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            _selectedPair = Pairs?.FirstOrDefault(x => x.Selected);
        }

        #endregion Methods

        #region Properties

        [Inject]
        ITradePageService TradePageService { get; set; }

        [Parameter]
        public ExchangePairModel[] Pairs { get; set; }

        public IEnumerable<string> MasterCurrencies =>
            Pairs?.Where(x => x.QuoteAsset.Extended.IsMaster).Select(x => x.QuoteAsset.Code).Distinct();

        #endregion Properties
    }
}
