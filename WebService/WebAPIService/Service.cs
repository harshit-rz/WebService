using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.WebAPIService
{
    public abstract class Service
    {



        protected Service()
        {
            _methods = GetMethods().ToList();
        }



        private List<ServiceMethod> _methods = null;



        public IEnumerable<ServiceMethod> Methods => _methods;



        private List<ServiceMethod> GetMethods()
        {
            var metadata = this.GetType()
                .GetMethods()
                .Where(ServiceMethod.IsValid)
                .Select(m => new { Method = m, Attribute = m.GetCustomAttributes(typeof(WebOperationAttribute), false).Single() as WebOperationAttribute });
            List<ServiceMethod> methods = new List<ServiceMethod>();
            foreach (var data in metadata)
            {
                var method = new ServiceMethod
                {
                    MethodInfo = data.Method,
                    Method = data.Attribute?.Method,
                    Route = data.Attribute?.Route,
                    ResponseType = data.Method.ReturnType,
                    RequestType = data.Method.GetParameters().Single().ParameterType
                };
                methods.Add(method);
            }
            return methods;
        }



        public HttpRs Invoke(HttpRq rq)
        {
            var method = this
                            .Methods
                            .SingleOrDefault(m => m.Match(rq) == true);
            var input = method.ParseRequest(rq);
            var output = method.Invoke(this, input);
            return HttpRs.Ok(method.ToResponse(output));



        }
    }
}
