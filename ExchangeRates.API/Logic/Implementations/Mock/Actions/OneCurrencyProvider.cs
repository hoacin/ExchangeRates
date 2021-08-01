using ExchangeRates.API.Logic.Implementations.Mock.Helpers;
using System.Threading.Tasks;

namespace ExchangeRates.API.Logic.Implementations.Mock.Actions
{
    static class OneCurrencyProvider
    {
        public static Task<(ExchangeRateModel, ExchangeRateError)> GetOneCurrencyAsync(string ddmmyyyy, string currencyCode)
        {
            ExchangeRateModel model = ExchangeRateModel.EmptyModel;
            if (!DateTester.TestDate(ddmmyyyy, out ExchangeRateError errorCode))
                return Task.FromResult((model, errorCode));
            if (currencyCode != "EUR")
                return Task.FromResult((model, ExchangeRateError.CurrencyNotFound));
            model = new ExchangeRateModel("EUR", 24.8, 1);
            return Task.FromResult((model, ExchangeRateError.Success));
        }
    }
}
