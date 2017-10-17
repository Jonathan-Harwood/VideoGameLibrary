namespace VideoGameLibrary
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class DataService
    {
        private const string apiKey = "71d6099b36158614fe4a21d830a17b47c387e7b6";

        public static async Task<dynamic> getDataFromService(string endpoint, string queryString)
        {
            string fullQuery = $"http://www.giantbomb.com/{endpoint}/?format=json&api_key={apiKey}{queryString}";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(fullQuery);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}
