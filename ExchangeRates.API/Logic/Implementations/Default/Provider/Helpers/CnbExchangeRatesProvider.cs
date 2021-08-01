using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers
{
    class CnbExchangeRatesProvider
    {
        private const string RegionPrefix = "ExchangeRatesCache";

        private readonly IMemoryCache _memoryCache;
        private readonly CnbRatesDownloader _cnbRatesDownloader;

        public CnbExchangeRatesProvider(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory)
        {
            _memoryCache = memoryCache;
            _cnbRatesDownloader = new CnbRatesDownloader(httpClientFactory);
        }

        public async Task<(ExchangeRateModel[]? models, ExchangeRateError errorCode)> GetExchangeRatesForDay(string cnbDateFormat)
        {
            string keyInCache = $"{RegionPrefix}{cnbDateFormat}";
            if (_memoryCache.TryGetValue(keyInCache, out object ratesTable))
                return ((ExchangeRateModel[])ratesTable, ExchangeRateError.Success);
            var downloadResult = await _cnbRatesDownloader.DownloadExchangeRatesAsync(cnbDateFormat);
            if (downloadResult.errorCode != ExchangeRateError.Success)
                return (null, downloadResult.errorCode);
            var parsingResult = CnbContentParser.Parse(downloadResult.cnbContent, cnbDateFormat);
            if (parsingResult.errorCode != ExchangeRateError.Success)
                return (null, parsingResult.errorCode);
            _ = _memoryCache.Set(keyInCache, parsingResult.models);
            return (parsingResult.models, ExchangeRateError.Success);
        }
    }
}
