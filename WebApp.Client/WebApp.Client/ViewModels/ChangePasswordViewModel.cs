using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Client.Models;

namespace WebApp.Client.ViewModels
{
    public class ChangePasswordViewModel
    {
        private IApiServices apiServices = Bootstrap.ServiceProvider.GetService<IApiServices>();

        public ChangePassword ChangePassword { get; set; }

        public ChangePasswordViewModel()
        {
            ChangePassword = new ChangePassword();
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var request = await apiServices.ChangePasswordAsync(ChangePassword);

                    if (request.IsSucces)
                    {
                        await Application.Current.MainPage.DisplayAlert("Message", "Password changed", "Ok");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", request.ErrorRequest.GetMessage(), "Ok");
                    }
                });
            }
        }
    }
}
