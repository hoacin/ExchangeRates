using ExchangeRates.API.Init;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ExchangeRates.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    _ = webBuilder.UseStartup<Startup>();
                });
    }
}
