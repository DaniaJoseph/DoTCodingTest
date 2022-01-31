using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Base
{
    public class TestInitializeHooks
    {
        public Uri BaseUrl { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();
        public IRestRequest Request { get; set; }
        public IRestResponse Response { get; set; }
    }
}
