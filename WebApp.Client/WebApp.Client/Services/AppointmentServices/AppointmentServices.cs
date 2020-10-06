using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models.Appointment;

namespace WebApp.Client.Services.AppointmentServices
{
    class AppointmentServices : IAppointmentServices
    {
        public async Task<List<AppointmentView>> GetAppointmentAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync(AppSettingsManager.Settings["Url"] + "/api/appointments");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AppointmentView>>(content);
        }

        public async Task<bool> MakeAppointmentAsync(AppointmentCreate appointment)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var json = JsonConvert.SerializeObject(appointment);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(AppSettingsManager.Settings["Url"] + "/api/appointments", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            HttpContent content = new StringContent(id.ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(AppSettingsManager.Settings["Url"] + "/api/appointments/remove", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAppointmentment(AppointmentCreate appointment)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var json = JsonConvert.SerializeObject(appointment);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(AppSettingsManager.Settings["Url"] + $"/api/appointments/edit?id={appointment.Id}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<AppointmentView>> GetAppointmentAsync(int doctorId, DateTime date)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync(AppSettingsManager.Settings["Url"] + $"/api/appointments/GetAppointments?doctorid={doctorId}&date={date.ToString("yyyyMMdd")}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AppointmentView>>(content);
        }
    }
}
