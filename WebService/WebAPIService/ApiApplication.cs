using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebService.Contracts.IWebAppliaction;

namespace WebService.WebAPIService
{
    public class ApiApplication : IWebApplication
    {
        private Service _service;

        public ApiApplication(Service service)
        {
            _service = service;
        }

        public HttpRs Handle(HttpRq request)
        {
            return _service.Invoke(request);
        }
    }
}
