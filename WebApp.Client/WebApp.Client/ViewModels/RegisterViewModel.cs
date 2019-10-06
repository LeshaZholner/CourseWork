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
    public class RegisterViewModel
    {
        private IApiServices apiServices = DiCollection.ServiceProvider.GetService<IApiServices>();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() => 
                {
                    var isSucces = await apiServices.RegisterAsync(Email,Password,ConfirmPassword);

                    if (isSucces)
                    {
                        Message = "Register is succesfully";
                    }
                    else
                    {
                        Message = "Retry later";
                    }
                });
            }
        }
    }
}
