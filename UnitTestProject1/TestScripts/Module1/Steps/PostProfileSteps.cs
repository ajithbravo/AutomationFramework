using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTestProject1.BaseClasses;
using UnitTestProject1.Modal;
using UnitTestProject1.Utility;

namespace UnitTestProject1.TestScripts.Module1.Steps
{
    [Binding]
    public sealed class PostProfileSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly Settings _settings;
        public PostProfileSteps(Settings settings)
        {
            _settings = settings;
        }

        [Given(@"I Perform POST operation for ""(.*)"" with body")]
        public void GivenIPerformPOSTOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _settings.Request = new RestRequest(url,Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new { name = data.name.ToString() });
            _settings.Request.AddUrlSegment("profileNo",data.profile.ToString());
            _settings.Response = _settings.RestClient.ExecutePostTaskAsync<Post>(_settings.Request).GetAwaiter().GetResult();
        
        }
        

    }
}
