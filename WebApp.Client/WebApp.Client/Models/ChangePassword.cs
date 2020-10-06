using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models
{
    public class ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
