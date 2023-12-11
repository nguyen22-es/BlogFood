using Newtonsoft.Json;
using System.Net.Http;

namespace FoodAdminClient.Service
{
    public class Token
    {
        public readonly HttpClient _httpClient;
        public Token(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }
        public async Task<string> GetAccessToken()
        {
            var response = await _httpClient.PostAsync("oauth2/token", new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("client_id", "b486ad2efa3816e"),
            new KeyValuePair<string, string>("client_secret", "ac7a2fa82596eb06849d1f137529a54ce4c70c38"),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        }));

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(result);
            return json.access_token;
        }
    }
}
