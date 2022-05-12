using GoSocketReadXml.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GoSocketReadXml.Data.Service
{
    public class XmlFunctionsService : IXmlFunctions
    {
        public XDocument document { get; set; }        
        public string GetNodesAreaEmployees()
        {
            var results = this.document.Descendants("area").Select(x => x.Elements("employees").DescendantNodes().Count()).Where(x => x > 2).Count();
            return $"Hay {results.ToString()} nodos de tipo '<area>' que tienen más de 2 empleados";
        }

        public List<string> GetNodesAreaTotalSalary()
        {
            var results = this.document.Descendants("area").Select(x => $"{x.Element("name").Value} | {x.Elements("employees").DescendantNodes().Select(xl => Convert.ToDouble((xl as XElement).Attribute("salary").Value.Replace(".", ","))).Sum()}").ToList();
            return results;
        }

        public string GetNodesCount()
        {
            int countNodes = this.document.Descendants("area").Count();
            return $"Hay {countNodes.ToString()} nodos de tipo '<area>'";
        }

        public void SetDocument(string ruta)
        {
            XmlDocument xmlGOSocket = new XmlDocument();
            xmlGOSocket.Load(ruta);
            this.document = XDocument.Parse(xmlGOSocket.InnerXml); 
        }
    }
}
