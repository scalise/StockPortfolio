using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.Common;
using System.Collections.Generic;

namespace StockPortfolio.Services
{
    public static class PortfolioPositions
    {
        [FunctionName("PortfolioPositions")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "portfolio/{portfolio}/positions")] HttpRequest req,
            ILogger log, string portfolio)
        {
            log.LogInformation("PortfolioPositions called");
                        
            string portfolioName = portfolio;
            
            //check body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);            
            portfolioName = portfolioName ?? data?.portfolioName;

            if (String.IsNullOrEmpty(portfolioName))
                return new BadRequestResult();

            // look up by username
            var resp = new PortfolioPositionsResponse()
            {
                Positions = new List<PortfolioPositionItem>()
                {
                    new PortfolioPositionItem() {AssetType = AssetType.Stock, Identifier = "IBM", AvgPrice = 102.12, Quantity = 100, CurrPrice = 101.97, PositionType = PositionType.Long, Change = 0.12, ChangePercent = 1.8, MarketValue = 9999.99},
                    new PortfolioPositionItem() {AssetType = AssetType.Stock, Identifier = "GE", AvgPrice = 5.62, Quantity = 200, CurrPrice = 6.73, PositionType = PositionType.Long, Change = 0.12, ChangePercent = 1.8, MarketValue = 9999.99 },
                    new PortfolioPositionItem() {AssetType = AssetType.Stock, Identifier = "MSFT", AvgPrice = 102.12, Quantity = 300, CurrPrice = 212.92, PositionType = PositionType.Long, Change = 0.12, ChangePercent = 1.8, MarketValue = 9999.99 },
                }
            };
            return new OkObjectResult(resp);
        }
    }

    public class PortfolioPositionsResponse
    {
        public IEnumerable<PortfolioPositionItem> Positions;
    }

    public class PortfolioPositionItem
    {
        public AssetType AssetType;
        public string Identifier;
        public double Quantity;
        public double AvgPrice;
        public double CurrPrice;
        public PositionType PositionType;
        public double Change;
        public double ChangePercent;
        public double MarketValue;
    }

    public enum AssetType { Stock }
    public enum PositionType { Long };
}
