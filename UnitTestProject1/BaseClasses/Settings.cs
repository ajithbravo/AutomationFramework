using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Modal;

namespace UnitTestProject1.BaseClasses
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse<Post> Response { get; set; }
        public IRestRequest Request { get; set; }
        public RestClient RestClient { get; set; } = new RestClient();
    }
}
