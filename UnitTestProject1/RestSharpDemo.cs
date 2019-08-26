using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Modal;

namespace UnitTestProject1
{
    [TestFixture]
    public class RestSharpDemo
    {
        RestClient client;
        [SetUp]
        public void Init()
        {
            client = new RestClient("http://localhost:4000");           
        }
        [Test]
        public void TestRestApi_Get_With_Deserializer()
        {
            //Arrange
            var request = new RestRequest("posts/{postid}", Method.GET);           
            request.AddUrlSegment("postid",1);
            //Act
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];
            //Assert
            Assert.That(result, Is.EqualTo("Batra"), "Author is not correct");
        }

        [Test]
        public void TestRestApi_Get_With_JObject()
        {
            //Arrange
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 2);

            //Act
            var response = client.Execute(request);
            JObject obs = JObject.Parse(response.Content);            
            var result = obs["title"];
            Assert.That(result.ToString(), Is.EqualTo("Appium with c#"), "Title is not correct");
        }

        [Test]
        public void TestRestApi_Post_With_AnonymousBody()
        {
            //Arrange
            var request = new RestRequest("posts/{postid}/profile", Method.POST);
            request.RequestFormat= DataFormat.Json;
            request.AddBody(new { name = "James" });
            request.AddUrlSegment("postid",1);

            //Act
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["name"];
            //Assert
            Assert.That(result, Is.EqualTo("James"), "Name is not correct");
        }

        [Test]
        public void TestRestApi_Post_With_ClassBody()
        {
            //Arrange
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Post(){author = "Satai", id="11", title= "Jira Tutor"});
            

            //Act
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["author"];
            //Assert
            Assert.That(result, Is.EqualTo("Satai"), "Author is not correct");
        }

        [Test]
        public void TestRestApi_Post_Generic_With_ClassBody()
        {
            //Arrange
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Post() { author = "Dilson", id = "10", title = "AWS tutor" });

            //Act
            var response = client.Execute<Post>(request);           
           //Assert
            Assert.That(response.Data.author, Is.EqualTo("Dilson"), "Author is not correct");
        }


    }
}
