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
    public static class PortfolioSummary
    {
        [FunctionName("PortfolioSummary")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "portfolio/{portfolio}/summary")] HttpRequest req,
            ILogger log, string portfolio)
        {
            log.LogInformation("PortfolioSummary called");

            string portfolioName = portfolio;

            if (String.IsNullOrEmpty(portfolioName))
                return new BadRequestResult();

            // look up by username
            var resp = new PorfolioSummaryResponse() { Balance = 123456.78, TodaysNetChangeValue = 100.00, TodaysNetChangePercent = 3.5, TotalCash = 100.00, Positions = 123356.78 };
            return new OkObjectResult(resp);
        }
    }
       

    public class PorfolioSummaryResponse
    {
        public double Balance;
        public double TodaysNetChangeValue;
        public double TodaysNetChangePercent;
        public double TotalCash;
        public double Positions;
    }

}
