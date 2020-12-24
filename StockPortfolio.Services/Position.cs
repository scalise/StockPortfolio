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
    public static class Position
    {
        [FunctionName("Position")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "portfolio/{portfolio}/position")] HttpRequest req,
            ILogger log)
        {               

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<PositionRequest>(requestBody);

            //TODO: Do something with the data

            log.LogInformation("position added");

            var adj = Math.Round(new Random().NextDouble() * 10.0, 2);
            var responseMessage = new PositionResponse()
            {
                Ticker = data.Ticker,
                Name = data.Name,
                NumShares = data.NumShares,
                AvgPurchasePrice = data.PurchasePrice,
                CurrentPrice = data.PurchasePrice + adj,
                MarketValue = data.NumShares * (data.PurchasePrice + adj),
                GainValue = (data.NumShares * (data.PurchasePrice + adj)) - (data.NumShares * data.PurchasePrice),
                GainPercentage = Math.Round(((data.NumShares * (data.PurchasePrice + adj)) - (data.NumShares * data.PurchasePrice)) / (data.NumShares * (data.PurchasePrice + adj)), 1),
            };
            return new OkObjectResult(responseMessage);
        }
    }

    public class PositionRequest
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public int NumShares { get; set; }
        public double PurchasePrice { get; set; }
    }

    public class PositionResponse
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public int NumShares { get; set; }
        public double AvgPurchasePrice { get; set; }
        public double CurrentPrice { get; set; }
        public double MarketValue { get; set; }
        public double GainValue { get; set; }
        public double GainPercentage { get; set; }
    }
}
