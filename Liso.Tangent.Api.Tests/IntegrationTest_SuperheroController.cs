using System;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Liso.Tangent.Api.Tests
{
    [TestClass]
    public class IntegrationTest_SuperheroController
    {
        #region Properties

        private HttpClient _testClient;
        private TestServer _testServer;
        private string _addFavourite = "Superhero/favourite";
        private string _getFavourite = "Superhero/favourites";
        private string _getById = "Superhero/getById?id=";
        private string _getByName = "Superhero/getByName?name=";

        #endregion

        #region Initialize

        /// <summary>
        /// Initializes the tests.
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            _testServer = new TestServer(new WebHostBuilder()
                                        .UseEnvironment("Development")
                                        .UseConfiguration(new ConfigurationBuilder()
                                                          .AddJsonFile("appsettings.json")
                                                          .Build())
                                        .UseStartup<Startup>());            
            _testClient = _testServer.CreateClient();
            _testClient.BaseAddress = new Uri(@"https://localhost:5001/api/");
            _testClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Cleans up the tests.
        /// </summary>
        [TestCleanup]
        public void CleanupTests()
        {
            _testClient?.Dispose();
            _testServer?.Dispose();
        }

        #endregion

        #region Tests

        [TestMethod]
        [TestCategory("IntegrationTest")]
        public void TestMethod_AddFavourite_Success()
        {
            //Arrange
            var favourite = TestData.GetFavourites().First();
            var request = new HttpRequestMessage(HttpMethod.Post, _addFavourite);
            var jsonData = JsonConvert.SerializeObject(favourite);
            request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Act
            HttpResponseMessage response = _testClient.SendAsync(request).Result;

            //Assert
            Assert.IsNotNull(response);
            string responseContent = response.Content.ReadAsStringAsync().Result.ToString().Replace("\"", string.Empty);
            Assert.IsNotNull(responseContent);
        }

        #endregion
    }
}
