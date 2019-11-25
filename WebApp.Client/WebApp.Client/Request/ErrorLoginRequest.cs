using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Request
{
    public class ErrorLoginRequest : IErrorRequest
    {
        [JsonProperty(PropertyName = "error_description")]
        public string Message { get; set; }
        public string GetMessage()
        {
            return Message;
        }
    }
}
