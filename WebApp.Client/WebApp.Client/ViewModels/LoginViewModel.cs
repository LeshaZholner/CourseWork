using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Client.ViewModels
{
    public class LoginViewModel
    {
        private IApiServices apiServices = DiCollection.ServiceProvider.GetService<IApiServices>();
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
