using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebService.WebAPIService
{
    public class ServiceMethod
    {
        internal static bool IsValid(MethodInfo method)
        {
            return
                method.IsDefined(typeof(WebOperationAttribute), false) == true &&
                method.GetParameters().Count() == 1;
        }



        public string Method { get; set; }



        public Type RequestType { get; set; }



        public Type ResponseType { get; set; }
        public string Route { get; internal set; }



        public MethodInfo MethodInfo { get; set; }



        public bool Match(HttpRq rq)
        {
            return
                rq.Method == this.Method &&
                rq.Url.StartsWith(this.Route);
        }



        internal object ParseRequest(HttpRq rq)
        {



            return JsonSerializer.Deserialize(rq.Content, this.RequestType);
        }



        internal object Invoke(Service service, object input)
        {
            return this.MethodInfo.Invoke(service, new object[] { input });
        }



        internal Stream ToResponse(object output)
        {
            var buffer = JsonSerializer.SerializeToUtf8Bytes(output, this.ResponseType);
            return new MemoryStream(buffer);
        }
    }
}
