using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRates.API.Logic
{
    public sealed class ExchangeRateModel
    {
        public static readonly ExchangeRateModel EmptyModel = new("", 0, 0);

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
