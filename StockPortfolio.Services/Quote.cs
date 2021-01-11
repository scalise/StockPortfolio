using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AlphaVantage.Net.Core.Client;
using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.Client;
using Microsoft.Extensions.Options;

namespace StockPortfolio.Services
{
    public interface IQuote
    {
        Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "quote/{ticker}")] HttpRequest req,
            ILogger log, string ticker);
    }

    public class Quote
    {
        private IOptions<MyConfiguration> _config;

        public Quote(IOptions<MyConfiguration> config)
        {
            _config = config;
        }

        [FunctionName("Quote")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "quote/{ticker}")] HttpRequest req,
            ILogger log, string ticker)
        {
            log.LogInformation("Quote called");
            
            if (string.IsNullOrEmpty(ticker))
                return new BadRequestResult();

            // use your AlphaVantage API key
            string apiKey = _config.Value.AlphaVantageApiKey;
            using var client = new AlphaVantageClient(apiKey);
            using var stocksClient = client.Stocks();
            GlobalQuote globalQuote = await stocksClient.GetGlobalQuoteAsync(ticker);
            
            var resp = new QuoteResponse() { Ticker = ticker, CurrentPrice = globalQuote.Price, Volume = globalQuote.Volume, PriceChange = globalQuote.Change, PercentChange = globalQuote.ChangePercent };
            return new OkObjectResult(resp);
        }
    }

    public class QuoteResponse
    {
        public string Ticker;
        public decimal CurrentPrice;
        public decimal PriceChange;
        public decimal PercentChange;
        public decimal Volume;        
    }    
}
