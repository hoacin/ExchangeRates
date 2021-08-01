using Microsoft.AspNetCore.Mvc;

namespace ExchangeRates.API.Logic.Helpers
{
    static class ErrorResponseProvider
    {
        public static ActionResult<SuccessType> CreateResponse<SuccessType>(this ControllerBase controllerBase, ExchangeRateError errorCode, SuccessType successObject)
        {
            return errorCode switch
            {
                ExchangeRateError.InvalidTimeFormat => controllerBase.BadRequest("Invalid time format. Use ddMMyyyy '05072021' for example."),
                ExchangeRateError.ResourceNotFound => controllerBase.NotFound("Exchange rates for desired time perion not found."),
                ExchangeRateError.CurrencyNotFound => controllerBase.NotFound("Currency not found. Use upper case codes like 'EUR'."),
                ExchangeRateError.ServiceDown => controllerBase.StatusCode(500, "Exchange rate service is not responding."),
                ExchangeRateError.Success => successObject,
                _ => controllerBase.StatusCode(500, "Internal server error.")
            };
        }
    }
}
