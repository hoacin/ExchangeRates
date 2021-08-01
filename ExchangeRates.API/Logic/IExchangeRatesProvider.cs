using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic
{
    public interface IExchangeRatesProvider
    {
        Task<(ExchangeRateModel model, ExchangeRateError errorCode)> GetOneCurrencyAsync(string ddmmyyyy, string currencyCode);
        Task<(IEnumerable<ExchangeRateModel>? models, ExchangeRateError errorCode)> GetAllCurrenciesAsync(string ddmmyyyy);
    }
}
