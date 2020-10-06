using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models.Doctor;

namespace WebApp.Client.Services.DoctorServices
{
    public class DoctorServices : IDoctorServices
    {
        public async Task<DoctorView> GetDoctorAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync(AppSettingsManager.Settings["Url"] + $"/api/doctors?id={id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DoctorView>(content);
        }

        public async Task<List<DoctorView>> GetDoctorsAsync(int? id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync(AppSettingsManager.Settings["Url"] + $"/api/doctors/getdoctorsbyspecializationId?specializationId={id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DoctorView>>(content);
        }
    }
}
