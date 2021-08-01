using ExchangeRates.API.Logic.Implementations.Mock.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Mock
{
    class MockExchangeRatesProvider : IExchangeRatesProvider
    {
        public Task<(IEnumerable<ExchangeRateModel>, ExchangeRateError)> GetAllCurrenciesAsync(string ddmmyyyy)
        {
            return CurrenciesProvider.GetAllCurrenciesAsync(ddmmyyyy);
        }

        public Task<(ExchangeRateModel, ExchangeRateError)> GetOneCurrencyAsync(string ddmmyyyy, string currencyCode)
        {
            return OneCurrencyProvider.GetOneCurrencyAsync(ddmmyyyy, currencyCode);
        }
    }
}
