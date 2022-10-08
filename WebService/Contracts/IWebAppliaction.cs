using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Contracts
{
    internal interface IWebAppliaction
    {

        public interface IWebApplication
        {
            HttpRs Handle(HttpRq rq);
        }
    }
}
