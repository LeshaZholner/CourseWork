using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.SpecializationServices
{
    class SpecializationServices : ISpecializationServices
    {
        public async Task<List<Specialization>> GetSpecializationsAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties["access_token"].ToString());

            var response = await client.GetAsync(AppSettingsManager.Settings["Url"]+"/api/Specializations");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Specialization>>(content);
        }
    }
}
