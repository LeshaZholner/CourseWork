using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.DoctorAvailabilityServices
{
    class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        public async Task<List<DoctorAvailabilityView>> GetDoctorAvailabilitiesAsync(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync(AppSettingsManager.Settings["Url"] + $"/api/DoctorAvailability?doctorId=1{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DoctorAvailabilityView>>(content);
        }
    }
}
