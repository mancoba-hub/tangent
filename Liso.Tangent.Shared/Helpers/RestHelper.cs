using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace Liso.Tangent
{
    public class RestHelper : IRestHelper
    {
        #region Properties

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestHelper"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public RestHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Implemented Members

        /// <summary>
        /// Searches for the superhero by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<RestApiResponse> SearchSuperhero(string name)
        {
            var jsonString = await MakeRestCall(0, name);
            var superhero = JsonConvert.DeserializeObject<RestApiResponse>(jsonString);
            return superhero;
        }

        /// <summary>
        /// Searches for the superhero by id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SuperheroResponse> SearchSuperhero(int id)
        {
            var jsonString = await MakeRestCall(id, null);
            var superhero = JsonConvert.DeserializeObject<SuperheroResponse>(jsonString);
            return superhero;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Makes the rest call for superhero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<string> MakeRestCall(int id, string name)
        {
            var token = _configuration["SuperheroApi:AuthToken"];
            var baseUrl = _configuration["SuperheroApi:BaseUrl"];
            var byName = _configuration["SuperheroApi:ByName"];
            var url = _configuration["SuperheroApi:Endpoint"].Replace("{token}", token);

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string endpoint = !string.IsNullOrWhiteSpace(name) ? $"{url}{byName}{name}" : $"{url}/{id}";

            HttpResponseMessage response = await client.GetAsync(endpoint).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        #endregion
    }
}
