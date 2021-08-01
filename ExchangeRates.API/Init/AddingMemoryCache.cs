using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRates.API.Init
{
    static class AddingMemoryCache
    {
        public static void AddExchangeRateCache(this IServiceCollection services)
        {
            _ = services.AddMemoryCache();
        }
    }
}
