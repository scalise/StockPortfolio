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
        [FunctionName("AddPosition")]
        public static async Task<IActionResult> AddPosition(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "portfolio/{portfolio}/position")] HttpRequest req,
             ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<PositionRequest>(requestBody);

            //TODO: Do something with the data

            log.LogInformation("position added");
            //TODO: REMOVE dummmy data below
            var adj = Math.Round(new Random().NextDouble() * 10.0, 2);
            var responseMessage = new PositionResponse()
            {
                Ticker = data.Ticker,
                Name = data.Name,
                NumShares = data.NumShares,
                AvgPurchasePrice = data.PurchasePrice,
                CurrentPrice = Math.Round(data.PurchasePrice + adj, 2),
                MarketValue = Math.Round(data.NumShares * (data.PurchasePrice + adj), 2),
                GainValue = Math.Round((data.NumShares * (data.PurchasePrice + adj)) - (data.NumShares * data.PurchasePrice), 2),
                GainPercentage = Math.Round(((data.NumShares * (data.PurchasePrice + adj)) - (data.NumShares * data.PurchasePrice)) / (data.NumShares * data.PurchasePrice) * 100.0, 1),
            };
            if (data.Ticker == "T") responseMessage.NumShares += 100;
            //-- REMOVE dummmy data below

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("UpdatePosition")]
        public static async Task<IActionResult> UpdatePosition(
           [HttpTrigger(AuthorizationLevel.Function, "put", Route = "portfolio/{portfolio}/position/{ticker}")] HttpRequest req,
            ILogger log, string ticker)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<PositionRequest>(requestBody);

            //TODO: Do something with the data

            log.LogInformation("position updated");
            //TODO: REMOVE dummmy data below
            var adj = Math.Round(new Random().NextDouble() * 10.0, 2);
            var responseMessage = new PositionResponse()
            {
                Ticker = ticker,
                Name = data.Name,
                NumShares = data.NumShares,
                AvgPurchasePrice = data.PurchasePrice,
                CurrentPrice = Math.Round(data.PurchasePrice + adj, 2),
                MarketValue = Math.Round(data.NumShares * (data.PurchasePrice + adj), 2),
                GainValue = Math.Round((data.NumShares * (data.PurchasePrice + adj)) - (data.NumShares * data.PurchasePrice), 2),
                GainPercentage = Math.Round(((data.NumShares * (data.PurchasePrice + adj)) - (data.NumShares * data.PurchasePrice)) / (data.NumShares * data.PurchasePrice) * 100.0, 1),
            };
            if (data.Ticker == "T") responseMessage.NumShares += 100;
            //-- REMOVE dummmy data below

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("DeletePosition")]
        public static async Task<IActionResult> DeletePosition(
           [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "portfolio/{portfolio}/position/{ticker}")] HttpRequest req,
            ILogger log, string ticker)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<PositionRequest>(requestBody);

            //TODO: Do something with the data

            log.LogInformation("position deleted");
            
            return new OkResult();
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
