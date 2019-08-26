using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Utility
{
    public static class Utility
    {
        //public static void CaptureScreenShot(IWebDriver driver, string screenShotName)
        //{
        //    try
        //    {
        //        TakesScreenshot ts = (TakesScreenshot)driver;
        //        File source = ts.GetScreenshot(OutputType.FILE);

        //    }
        //    catch
        //    {

        //    }
        //}
        public static Dictionary<string, string> DeserilaizeResponse(this IRestResponse restResponse)
        {
            var JsonObj = new JsonDeserializer().Deserialize<Dictionary<string, string>>(restResponse);
            return JsonObj;
        }
        public static string GetResponseObjects(this IRestResponse response, string responseObject)
        { 
            JObject jsonObs = JObject.Parse(response.Content);
            return jsonObs[responseObject].ToString();
        }

        public static string GetResponseListObjects(this IRestResponse response, string responseObject)
        {
            JArray jarryaObs = JArray.Parse(response.Content);
            string name = string.Empty;
            foreach(JObject jsonObs in jarryaObs)
            {
                name = jsonObs["name"].ToString();
            }
            return name;// jsonObs[responseObject];
        }
        public static async Task<IRestResponse<T>> ExecuteAsyncRequest<T>( this RestClient client, IRestRequest request) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            client.ExecuteAsync<T>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);

            });

            return await taskCompletionSource.Task;

        }

    }
}
