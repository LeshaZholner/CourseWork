using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.AppointmentServices
{
    class AppointmentServices : IAppointmentServices
    {
        public async Task<List<Appointment>> GetAppointmentAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync("https://webappapi20191004033419.azurewebsites.net/api/appointments");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Appointment>>(content);
        }

        public async Task<bool> MakeAppointmentAsync(Appointment appointment)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["Token"].ToString());

            var json = JsonConvert.SerializeObject(appointment);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://webappapi20191004033419.azurewebsites.net/api/appointments", content);

            return response.IsSuccessStatusCode;
        }
    }
}
