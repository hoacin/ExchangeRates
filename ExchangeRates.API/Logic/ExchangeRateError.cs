namespace ExchangeRates.API.Logic
{
    public enum ExchangeRateError
    {
        Success,
        CurrencyNotFound,
        ResourceNotFound,
        InvalidTimeFormat,
        ServiceDown,
        InternalError,
    }
}
