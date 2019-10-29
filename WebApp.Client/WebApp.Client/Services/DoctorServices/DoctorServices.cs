using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.DoctorServices
{
    public class DoctorServices : IDoctorServices
    {
        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync("https://lesha-zholner-webappapi.azurewebsites.net/api/doctors/getdoctorsbyspecializationId");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Doctor>>(content);
        }
    }
}
