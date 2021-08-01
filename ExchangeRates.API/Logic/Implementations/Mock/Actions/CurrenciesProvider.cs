using ExchangeRates.API.Logic.Implementations.Mock.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Mock.Actions
{
    static class CurrenciesProvider
    {
        public static Task<(IEnumerable<ExchangeRateModel>, ExchangeRateError)> GetAllCurrenciesAsync(string ddmmyyyy)
        {
            IEnumerable<ExchangeRateModel> models = null;
            if (!DateTester.TestDate(ddmmyyyy, out ExchangeRateError errorCode))
                return Task.FromResult((models, errorCode));
            models = new ExchangeRateModel[3]
            {
                new ExchangeRateModel("EUR", 25.5, 1),
                new ExchangeRateModel("GBP", 38.1, 1),
                new ExchangeRateModel("PHP", 43.7, 100)
            };
            return Task.FromResult((models, ExchangeRateError.Success));
        }
    }
}
