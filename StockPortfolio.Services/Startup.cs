using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockPortfolio.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

// register assembly
[assembly: FunctionsStartup(typeof(Startup))]
namespace StockPortfolio.Services
{
    // inherit FunctionsStartup
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                   //.SetBasePath(Environment.CurrentDirectory)  ← do not use
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("local.settings.json", true)
                   .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                   .AddEnvironmentVariables()
                   .Build();

            builder.Services.Configure<MyConfiguration>(config.GetSection("MyConfiguration"));

            builder.Services.AddOptions();
        }


    }
}

