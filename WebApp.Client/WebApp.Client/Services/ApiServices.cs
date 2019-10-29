using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services
{
    public class ApiServices : IApiServices
    {
        public async Task<bool> RegisterAsync(RegisterBindingModel model)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://lesha-zholner-webappapi.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            var key = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://lesha-zholner-webappapi.azurewebsites.net/Token");
            request.Content = new FormUrlEncodedContent(key);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<JwtToken>(content);
            App.Current.Properties["access_token"] = token.AccessToken;
            return response.IsSuccessStatusCode;
        }
    }
}
