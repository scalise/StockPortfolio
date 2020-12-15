using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace StockPortfolio.Services
{
    public static class PortfolioSummaryBalanceHistory
    {
        [FunctionName("PortfolioSummaryBalanceHistory")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "portfolio/{portfolio}/balancehistory")] HttpRequest req,
            ILogger log, string portfolio)
        {
            log.LogInformation("PortfolioSummaryBalanceHistory called");

            string portfolioName = portfolio;

            if (String.IsNullOrEmpty(portfolioName))
                return new BadRequestResult();

            // look up by username
            var resp = new PorfolioSummaryBalanceHistoryResponse() { 
                BalanceData = new List<BalanceDataPoint>() 
                {
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-8), Balance = 100000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-7), Balance = 323000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-6), Balance = 98000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-5), Balance = 99000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-4), Balance = 100000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-3), Balance = 110000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-2), Balance = 120000.00 },
                    new BalanceDataPoint() { BalanceDate = DateTime.Now.AddDays(-1), Balance = 130000.00 },
                }
            };
            return new OkObjectResult(resp);
        }
    }

    public class PorfolioSummaryBalanceHistoryResponse
    {
        public IEnumerable<BalanceDataPoint> BalanceData;
    }

    public class BalanceDataPoint
    {
        public DateTime BalanceDate;
        public double Balance;
    }

}
