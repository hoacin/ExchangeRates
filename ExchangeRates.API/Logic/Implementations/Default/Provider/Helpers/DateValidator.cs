using System;
using System.Globalization;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers
{
    static class DateValidator
    {
        public static bool TryConvertForCNB(string ddmmyyyy, out string dateForCNB)
        {
            dateForCNB = string.Empty;
            if (string.IsNullOrWhiteSpace(ddmmyyyy))
                return false;
            if (!DateTime.TryParseExact(ddmmyyyy, "ddMMyyyy", null, DateTimeStyles.None, out DateTime validDate))
                return false;
            dateForCNB = validDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            return true;
        }
    }
}
