using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Modal;
using UnitTestProject1.Utility;

namespace UnitTestProject1
{
    [TestFixture]
    public class JWTAuthentication
    {
        [Test]
        public void AuthenticationMechanism()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("auth/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { email = "techie@email.com", password= "techie" });
            var response = client.ExecutePostTaskAsync(request).GetAwaiter().GetResult();
            var access_token = response.GetResponseObjects("access_token");
            var jwtAuth = new JwtAuthenticator(access_token);
            client.Authenticator = jwtAuth;
            var getrequest = new RestRequest("products?_page=1&familyId=1", Method.GET);
           // getrequest.AddUrlSegment("postid", 1);
            //Perfomr Get operation
            var responses = client.ExecuteGetTaskAsync<List<Product>>(getrequest).GetAwaiter().GetResult();
            var result = responses.GetResponseListObjects("name");
           
            
            //var result = output["author"];

            Assert.That(result, Is.EqualTo("Product001"), "The Author name is wrong");
        }
    }
}
