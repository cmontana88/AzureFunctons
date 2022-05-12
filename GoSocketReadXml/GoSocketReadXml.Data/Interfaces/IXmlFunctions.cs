using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSocketReadXml.Data.Interfaces
{
    public interface IXmlFunctions
    {
        void SetDocument(string ruta);
        string GetNodesCount();
        string GetNodesAreaEmployees();
        List<string> GetNodesAreaTotalSalary();
    }
}
