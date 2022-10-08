using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class HttpRq
    {
        public string Url { get; set; }
        public Stream Content { get; set; }
        public string Method { get; set; }

    }
}
