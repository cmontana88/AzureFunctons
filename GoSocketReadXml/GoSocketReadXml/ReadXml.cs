using System;
using System.IO;
using System.Reflection;
using GoSocketReadXml.Data.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GoSocketReadXml
{
    public class ReadXml
    {
        private readonly IOptions<Configuration> _settings;
        private readonly IXmlFunctions _xmlFunctions;
        public ReadXml(IOptions<Configuration> settings, IXmlFunctions xmlFunctions)
        {
            _settings = settings;
            _xmlFunctions = xmlFunctions;
        }

        [FunctionName("ReadXml")]
        public void Run([TimerTrigger("0 */30 * * * *")]TimerInfo myTimer, ILogger log)
        {

            _xmlFunctions.SetDocument($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)}/../{_settings.Value.NombreXml}");

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            log.LogInformation(_xmlFunctions.GetNodesCount());

            foreach(string message in _xmlFunctions.GetNodesAreaTotalSalary())
            {
                log.LogInformation(message);
            }

            log.LogInformation(_xmlFunctions.GetNodesAreaEmployees());
        }
    }
}
