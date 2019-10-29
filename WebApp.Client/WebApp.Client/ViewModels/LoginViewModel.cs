using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Client.Views;

namespace WebApp.Client.ViewModels
{
    public class LoginViewModel
    {
        private IApiServices apiServices = Bootstrap.ServiceProvider.GetService<IApiServices>();
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () => {

                    var isSucces = await apiServices.LoginUserAsync(UserName, Password);
                    if (isSucces)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new AppointmentsPage());
                    }
                });
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
                });
            }
        }
    }
}
