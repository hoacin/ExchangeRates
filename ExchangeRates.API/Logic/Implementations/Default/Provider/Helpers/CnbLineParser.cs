using System.Globalization;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers
{
    static class CnbLineParser
    {
        public static ExchangeRateModel Parse(string cnbLine)
        {
            string[] columns = cnbLine.Split('|');
            if (!double.TryParse(columns[4].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double exchangeRate))
                return null;
            if (!int.TryParse(columns[2], NumberStyles.Any, CultureInfo.InvariantCulture, out int quantity))
                return null;
            return new ExchangeRateModel(columns[3], exchangeRate, quantity);
        }
    }
}
