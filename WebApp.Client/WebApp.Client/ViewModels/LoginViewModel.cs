using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.Services;
using Xamarin.Forms;

namespace WebApp.Client.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices apiServices = new ApiServices();
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () => {
                   await apiServices.LoginUserAsync(UserName, Password);
                });
            }
        }
    }
}
