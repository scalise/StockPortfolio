using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StockPortfolio.Services
{
    public static class Quote
    {
        [FunctionName("Quote")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "quote/{positionIdentifier}")] HttpRequest req,
            ILogger log, string positionIdentifier)
        {
            log.LogInformation("Quote called");

            if (string.IsNullOrEmpty(positionIdentifier))
                return new BadRequestResult();

            var resp = new QuoteResponse() { Identifier = positionIdentifier, CurrentPrice = 212.99, High52Week = 224.82, Low52Week = 179.76, PriceChange = 2.23, PercentChange = 1.27 };
            return new OkObjectResult(resp);
        }
    }

    public class QuoteResponse
    {
        public string Identifier;
        public double CurrentPrice;
        public double PriceChange;
        public double PercentChange;
        public double High52Week;
        public double Low52Week;
    }    
}
