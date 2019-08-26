using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using UnitTestProject1.BaseClasses;
using UnitTestProject1.Modal;
using UnitTestProject1.Utility;

namespace UnitTestProject1.TestScripts.Module1.Steps
{
    [Binding]
    public sealed class RestSharpSpecFlowDemoSteps
    {
        private readonly ScenarioContext context;
        private readonly Settings _settings;

        ////Added to setting and will be cosnumed using dependency injection

       // public RestClient client = new RestClient("http://localhost:3000/");
        //public RestRequest request = new RestRequest();
        //public IRestResponse<Post> response = new RestResponse<Post>();
        public RestSharpSpecFlowDemoSteps(ScenarioContext injectedContext , Settings settings)
        {
            context = injectedContext;
            _settings = settings;
        }

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            //_settings.RestClient.BaseUrl = new System.Uri(ConfigutaionManager.AppSettinga);
            _settings.Request = new RestRequest(url, Method.GET);
            
        }

        [Given(@"I perform operation for post ""(.*)""")]
        public void GivenIPerformOperationForPost(int postId)
        {
            //request.RequestFormat = DataFormat.Json;
            _settings.Request.AddUrlSegment("id", postId.ToString());
            _settings.Response = _settings.RestClient.ExecuteGetTaskAsync<Post>(_settings.Request).GetAwaiter().GetResult();

           // var response = client.Execute(request);
            
        }  

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObjects(key), Is.EqualTo(value), $"The {key} is not matching");
            
        }

    }
}
