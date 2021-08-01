using System;
using System.Globalization;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers
{
    static class TimeDifferenceValidator
    {
        private const int MaxAllowedDifferenceInDays = 7;

        public static bool IsValid(string firstLine, string desiredDate)
        {
            DateTime exchangeRateTime = DateTime.ParseExact(firstLine.Substring(0, 10), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime requestedDate = DateTime.ParseExact(desiredDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            double difference = Math.Abs((exchangeRateTime - requestedDate).TotalDays);
            if (difference > MaxAllowedDifferenceInDays)
                return false;
            return true;
        }
    }
}
