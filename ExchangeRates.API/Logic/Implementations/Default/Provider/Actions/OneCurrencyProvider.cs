using ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Actions
{
    class OneCurrencyProvider
    {
        private readonly CnbExchangeRatesProvider _cnbExchangeRatesProvider;

        public OneCurrencyProvider(CnbExchangeRatesProvider cnbExchangeRatesProvider)
        {
            _cnbExchangeRatesProvider = cnbExchangeRatesProvider;
        }

        public async Task<(ExchangeRateModel model, ExchangeRateError errorCode)> GetOneCurrencyAsync(string ddmmyyyy, string currencyCode)
        {
            if (!DateValidator.TryConvertForCNB(ddmmyyyy, out string cnbDateFormat))
                return (null, ExchangeRateError.InvalidTimeFormat);
            var (models, errorCode) = await _cnbExchangeRatesProvider.GetExchangeRatesForDay(cnbDateFormat);
            if (errorCode != ExchangeRateError.Success)
                return (null, errorCode);

            foreach (ExchangeRateModel model in models)
                if (model.CurrencyCode == currencyCode)
                    return (model, ExchangeRateError.Success);

            return (null, ExchangeRateError.CurrencyNotFound);
        }
    }
}
