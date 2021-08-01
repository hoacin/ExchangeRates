using ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Actions
{
    class CurrenciesProvider
    {
        private readonly CnbExchangeRatesProvider _cnbExchangeRatesProvider;

        public CurrenciesProvider(CnbExchangeRatesProvider cnbExchangeRatesProvider)
        {
            _cnbExchangeRatesProvider = cnbExchangeRatesProvider;
        }

        public async Task<(IEnumerable<ExchangeRateModel> models, ExchangeRateError errorCode)> GetAllCurrenciesAsync(string ddmmyyyy)
        {
            if (!DateValidator.TryConvertForCNB(ddmmyyyy, out string cnbDateFormat))
                return (null, ExchangeRateError.InvalidTimeFormat);
            var result = await _cnbExchangeRatesProvider.GetExchangeRatesForDay(cnbDateFormat);
            if (result.errorCode != ExchangeRateError.Success)
                return (null, result.errorCode);
            return result;
        }
    }
}
