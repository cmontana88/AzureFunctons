using GoSocketReadXml.Data.Interfaces;
using GoSocketReadXml.Data.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(GoSocketReadXml.Startup))]
namespace GoSocketReadXml
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);


        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<Configuration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("Configuration").Bind(settings);
                });

            builder.Services.AddTransient<IXmlFunctions, XmlFunctionsService>();

            
        }
    }
}
