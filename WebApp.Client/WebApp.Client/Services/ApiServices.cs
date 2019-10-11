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
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json,Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://webappapi20191004033419.azurewebsites.net/api/Account/Register", content);
            string result = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        public async Task LoginUserAsync(string username, string password)
        {
            var key = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://webappapi20191004033419.azurewebsites.net/Token");
            request.Content = new FormUrlEncodedContent(key);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var accessToken = JObject.Parse(content)["access_token"];
        }

        public async Task<bool> PostAppointemntAsync(Appointment appointment)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["Token"].ToString());

            var json = JsonConvert.SerializeObject(appointment);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://webappapi20191004033419.azurewebsites.net/api/appointments", content);
            string result = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }
    }
}
