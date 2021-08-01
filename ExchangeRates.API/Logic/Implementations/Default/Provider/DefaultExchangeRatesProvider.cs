using ExchangeRates.API.Logic.Implementations.Default.Provider.Actions;
using ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider
{
    class DefaultExchangeRatesProvider : IExchangeRatesProvider
    {
        private readonly CurrenciesProvider _currenciesProvider;
        private readonly OneCurrencyProvider _oneCurrencyProvider;

        public DefaultExchangeRatesProvider(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory)
        {
            CnbExchangeRatesProvider cnbExchangeRatesProvider = new(memoryCache, httpClientFactory);
            _currenciesProvider = new CurrenciesProvider(cnbExchangeRatesProvider);
            _oneCurrencyProvider = new OneCurrencyProvider(cnbExchangeRatesProvider);
        }
        public Task<(IEnumerable<ExchangeRateModel> models, ExchangeRateError errorCode)> GetAllCurrenciesAsync(string ddmmyyyy)
        {
            return _currenciesProvider.GetAllCurrenciesAsync(ddmmyyyy);
        }

        public Task<(ExchangeRateModel model, ExchangeRateError errorCode)> GetOneCurrencyAsync(string ddmmyyyy, string currencyCode)
        {
            return _oneCurrencyProvider.GetOneCurrencyAsync(ddmmyyyy, currencyCode);
        }
    }
}
