using ExchangeRates.API.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ExchangeRates.API.Init
{
    static class AddingSwaggerGen
    {
        public static void AddSwagerGenForExchangeRates(this IServiceCollection services)
        {
            OpenApiInfo apiInfo = new()
            {
                Title = CommonTexts.ApiTitle,
                Version = "v1",
                Description = CommonTexts.ApiDescription,
            };

            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", apiInfo);
            });
        }
    }
}
