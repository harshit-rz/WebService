using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public  class HttpRs
    {
        internal static HttpRs Ok(Stream content)
        {
            return new HttpRs
            {
                Content = content
            };
        }
        public Stream Content { get; set; }
    }
}
