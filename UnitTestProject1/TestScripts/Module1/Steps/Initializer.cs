using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnitTestProject1.BaseClasses;
using System.Configuration;

namespace UnitTestProject1.TestScripts.Module1.Steps
{
    [Binding]
    public class Initializer
    {
        private Settings _settings;
        public Initializer(Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            _settings.BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }

    }
}
