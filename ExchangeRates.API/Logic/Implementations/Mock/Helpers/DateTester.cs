namespace ExchangeRates.API.Logic.Implementations.Mock.Helpers
{
    static class DateTester
    {
        public static bool TestDate(string ddmmyyyy, out ExchangeRateError errorCode)
        {
            errorCode = ExchangeRateError.Success;
            if (ddmmyyyy is null || ddmmyyyy.Length != 8)
                errorCode = ExchangeRateError.InvalidTimeFormat;
            else if (ddmmyyyy == "notfound")
                errorCode = ExchangeRateError.ResourceNotFound;
            else
                return true;
            return false;
        }
    }
}
