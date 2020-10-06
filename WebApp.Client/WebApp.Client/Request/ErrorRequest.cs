using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.Client.Request
{
    public class ErrorRequest : IErrorRequest
    {
        public string Message { get; set; }

        public Dictionary<string, List<string>> ModelState { get; set; }

        public string GetMessage()
        {
            return string.Join("\n", ModelState.First().Value.ToArray());
        }
    }
}
