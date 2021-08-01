using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers
{
    class CnbRatesDownloader
    {
        private const string CnbApi = "https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt?date=";

        private readonly IHttpClientFactory _httpClientFactory;

        public CnbRatesDownloader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(string cnbContent, ExchangeRateError errorCode)> DownloadExchangeRatesAsync(string cnbDate)
        {
            string todayLink = $"{CnbApi}{cnbDate}";
            HttpClient client = _httpClientFactory.CreateClient();
            string cnbContent;
            try
            {
                cnbContent = await client.GetStringAsync(todayLink);
            }
            catch
            {
                return (null, ExchangeRateError.ServiceDown);
            }
            return (cnbContent, ExchangeRateError.Success);
        }
    }
}
