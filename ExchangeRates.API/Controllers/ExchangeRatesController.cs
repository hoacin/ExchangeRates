using ExchangeRates.API.Logic;
using ExchangeRates.API.Logic.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeRates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRatesProvider _exchangeRatesProvider;

        public ExchangeRatesController(IExchangeRatesProvider exchangeRatesProvider)
        {
            _exchangeRatesProvider = exchangeRatesProvider;
        }

        [HttpGet("{ddmmyyyy}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ExchangeRateModel>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse(500)]
        public async Task<ActionResult<IEnumerable<ExchangeRateModel>?>> GetExchangeRates(string ddmmyyyy)
        {
            var (models, errorCode) = await _exchangeRatesProvider.GetAllCurrenciesAsync(ddmmyyyy);
            return this.CreateResponse(errorCode, models);
        }

        [HttpGet("{ddmmyyyy}/{currency}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ExchangeRateModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        [SwaggerResponse(500)]
        public async Task<ActionResult<ExchangeRateModel>> GetExchangeRates(string ddmmyyyy, string currency)
        {
            var (model, errorCode) = await _exchangeRatesProvider.GetOneCurrencyAsync(ddmmyyyy, currency);
            return this.CreateResponse(errorCode, model);
        }
    }
}
