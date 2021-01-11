using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AlphaVantage.Net.Core.Client;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace StockPortfolio.Services
{
    public interface IResearch
    {
        Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "quote/{ticker}")] HttpRequest req,
            ILogger log, string ticker);
    }

    public class Research
    {
        private IOptions<MyConfiguration> _config;

        public Research(IOptions<MyConfiguration> config)
        {
            _config = config;
        }

        [FunctionName("Research")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "research/{ticker}")] HttpRequest req,
            ILogger log, string ticker)
        {
            log.LogInformation("Research called");

            if (string.IsNullOrEmpty(ticker))
                return new BadRequestResult();

            // use your AlphaVantage API key
            string apiKey = _config.Value.AlphaVantageApiKey;
            using var client = new AlphaVantageClient(apiKey);

            var query = new Dictionary<string, string>()
            {
                { "symbol", ticker }
            };
            var result = await client.RequestPureJsonAsync(AlphaVantage.Net.Common.ApiFunction.OVERVIEW, query);
            var overviewResp = JsonConvert.DeserializeObject<OverviewResponse>(result);                        
            return new OkObjectResult(overviewResp);
        }
    }


    public class OverviewResponse
    {
        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string FullTimeEmployees { get; set; }
        public string FiscalYearEnd { get; set; }
        public DateTime LatestQuarter { get; set; }
        public long MarketCapitalization { get; set; }
        public long EBITDA { get; set; }
        public decimal PERatio { get; set; }
        public decimal PEGRatio { get; set; }
        public decimal BookValue { get; set; }
        public decimal DividendPerShare { get; set; }
        public decimal DividendYield { get; set; }
        public decimal EPS { get; set; }
        public decimal RevenuePerShareTTM { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal OperatingMarginTTM { get; set; }
        public decimal ReturnOnAssetsTTM { get; set; }
        public decimal ReturnOnEquityTTM { get; set; }
        public long RevenueTTM { get; set; }
        public long GrossProfitTTM { get; set; }
        public decimal DilutedEPSTTM { get; set; }
        public decimal QuarterlyEarningsGrowthYOY { get; set; }
        public decimal QuarterlyRevenueGrowthYOY { get; set; }
        public decimal AnalystTargetPrice { get; set; }
        public decimal TrailingPE { get; set; }
        public decimal ForwardPE { get; set; }
        public decimal PriceToSalesRatioTTM { get; set; }
        public decimal PriceToBookRatio { get; set; }
        public decimal EVToRevenue { get; set; }
        public decimal EVToEBITDA { get; set; }
        public decimal Beta { get; set; }
        public decimal _52WeekHigh { get; set; }
        public decimal _52WeekLow { get; set; }
        public decimal _50DayMovingAverage { get; set; }
        public decimal _200DayMovingAverage { get; set; }
        public long SharesOutstanding { get; set; }
        public long SharesFloat { get; set; }
        public long SharesShort { get; set; }
        public long SharesShortPriorMonth { get; set; }
        public decimal ShortRatio { get; set; }
        public decimal ShortPercentOutstanding { get; set; }
        public decimal ShortPercentFloat { get; set; }
        public decimal PercentInsiders { get; set; }
        public decimal PercentInstitutions { get; set; }
        public decimal ForwardAnnualDividendRate { get; set; }
        public decimal ForwardAnnualDividendYield { get; set; }
        public decimal PayoutRatio { get; set; }
        public DateTime DividendDate { get; set; }
        public DateTime ExDividendDate { get; set; }
        public string LastSplitFactor { get; set; }
        public DateTime LastSplitDate { get; set; }
    }

}
