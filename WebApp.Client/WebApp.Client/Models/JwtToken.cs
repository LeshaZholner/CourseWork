using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models
{
    public class JwtToken
    {
        [JsonProperty(PropertyName ="access_token")]
        public string AccessToken { get; set; }
    }
}
