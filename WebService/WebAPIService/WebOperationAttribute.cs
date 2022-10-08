using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.WebAPIService
{
    internal class WebOperationAttribute:Attribute
    {
        public string Method { get; set; }
        public string Route { get; set; }
        public string Query { get; set; }
    }

}
