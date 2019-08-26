using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Apihelpers;
using UnitTestProject1.Modal;
using UnitTestProject1.Utility;

namespace UnitTestProject1
{
    [TestFixture]
    public class RestSharpAsync
    {
        RestClient client;
        [SetUp]
        public void Init()
        {
            client = new RestClient("http://localhost:4000");
        }

        [Test]
        public void TestRestApi_Post_Generic_With_Async()
        {
            //Arrange
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Post() { author = "Karry", id = "23", title = "Scrum Master" });

            //Act
            var response = ApiHelpers.ExecuteAsyncRequest<Post>(client, request).GetAwaiter().GetResult();
            //Assert
            Assert.That(response.Data.author, Is.EqualTo("Karry"), "Author is not correct");
        }

        [Test]
        public void TestRestApi_Post_With_AnonymousBody_Extensions()
        {
            //Arrange
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Post() { author = "Remmy", id = "14", title = "WPF tutor" });

            //Act
            var response = client.Execute(request);
            var result = response.DeserilaizeResponse()["author"];
            //Assert
            Assert.That(result, Is.EqualTo("Remmy"), "Name is not correct");
        }

        [Test]
        public void TestRestApi_Get_With_JObject_Extension()
        {
            //Arrange
            var request = new RestRequest("posts/{id}", Method.GET);
            request.AddUrlSegment("id", 13);

            //Act
            var response = client.Execute(request);
            var result = response.GetResponseObjects("title");
            //Assert
            Assert.That(result.ToString(), Is.EqualTo("WCF tutor"), "Title is not correct");
        }

        [Test]
        public void TestRestApi_Post_Generic_With_Async_Extension()
        {
            //Arrange
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Post() { author = "Thimir", id = "20", title = "WebPlaftform Methods" });

            //Act
            var response = client.ExecuteAsyncRequest<Post>(request).GetAwaiter().GetResult();
            //Assert
            Assert.That(response.Data.author, Is.EqualTo("Thimir"), "Author is not correct");
        }

        [Test]
        public void TestRestApi_Post_Generic_With_ExecutePostTaskAsync()
        {
            //Arrange
            var request = new RestRequest("posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Post() { author = "Bladder", id = "22", title = "Jsp tutor" });

            //Act
            var response = client.ExecutePostTaskAsync<Post>(request).GetAwaiter().GetResult();
            //Assert
            Assert.That(response.Data.author, Is.EqualTo("Ladder"), "Author is not correct");
        }

    }
}
