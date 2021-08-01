using ExchangeRates.API.Logic;
using ExchangeRates.API.Logic.Implementations.Default.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRates.API.Init
{
    static class AddingExchangeRatesProvider
    {
        public static void AddExchangeRatesProvider(this IServiceCollection services)
        {
            _ = services.AddScoped<IExchangeRatesProvider, DefaultExchangeRatesProvider>();
        }
    }
}
