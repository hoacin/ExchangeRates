using System;
using System.Collections.Generic;

namespace ExchangeRates.API.Logic.Implementations.Default.Provider.Helpers
{
    static class CnbContentParser
    {
        public static (ExchangeRateModel[]? models, ExchangeRateError errorCode) Parse(string cnbContent, string cnbDesiredDate)
        {
            List<ExchangeRateModel> exchangeRates = new();
            if (string.IsNullOrWhiteSpace(cnbContent))
                return (null, ExchangeRateError.InternalError);
            try
            {
                string[] lines = cnbContent.Trim().Split('\n', StringSplitOptions.None);
                if (!TimeDifferenceValidator.IsValid(lines[0], cnbDesiredDate))
                    return (null, ExchangeRateError.ResourceNotFound);
                foreach (string line in lines[2..])
                {
                    ExchangeRateModel? model = CnbLineParser.Parse(line);
                    if (model is null)
                        return (null, ExchangeRateError.InternalError);
                    exchangeRates.Add(model);
                }
            }
            catch
            {
                return (null, ExchangeRateError.InternalError);
            }
            return (exchangeRates.ToArray(), ExchangeRateError.Success);
        }
    }
}
