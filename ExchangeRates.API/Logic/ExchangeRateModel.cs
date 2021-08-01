using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRates.API.Logic
{
    public sealed class ExchangeRateModel
    {
        [Required]
        [JsonProperty(Required = Required.DisallowNull)]
        public string CurrencyCode { get; }
        public double ExchangeRate { get; }
        public int Quantity { get; }

        public ExchangeRateModel(string currencyCode, double exchangeRate, int quantity)
        {
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            Quantity = quantity;
        }
    }
}
