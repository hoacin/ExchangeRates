using ExchangeRates.API.Resources;
using Microsoft.AspNetCore.Builder;

namespace ExchangeRates.API.Init
{
    static class SwaggerConfigurator
    {
        public static void UseExchangeRatesSwagger(this IApplicationBuilder app)
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{CommonTexts.ApiTitle} v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
