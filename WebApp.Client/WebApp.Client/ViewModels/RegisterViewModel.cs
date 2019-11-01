using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Client.Views;
using WebApp.Client.Models;
using System.ComponentModel;

namespace WebApp.Client.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private IApiServices apiServices = Bootstrap.ServiceProvider.GetService<IApiServices>();

        private RegisterBindingModel registerModel;
        private bool isEmailValid;
        private bool isPasswordValid;
        private bool isConfirmPasswordValid;
        private bool isFirstNameValid;
        private bool isLastNameValid;
        private bool isPhonenumberValid;

        public RegisterViewModel()
        {
            registerModel = new RegisterBindingModel();
        }

        public string Email 
        {
            get { return registerModel.Email; }
            set
            {
                if(registerModel.Email != value)
                {
                    registerModel.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Password
        {
            get { return registerModel.Password; }
            set
            {
                if (registerModel.Password != value)
                {
                    registerModel.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public string ConfirmPassword
        {
            get { return registerModel.ConfirmPassword; }
            set
            {
                if (registerModel.ConfirmPassword != value)
                {
                    registerModel.ConfirmPassword = value;
                    OnPropertyChanged("ConfirmPassword");
                }
            }
        }

        public string FirstName
        {
            get { return registerModel.FirstName; }
            set
            {
                if(registerModel.FirstName != value)
                {
                    registerModel.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return registerModel.LastName; }
            set
            {
                if (registerModel.LastName != value)
                {
                    registerModel.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string PhoneNumber
        {
            get { return registerModel.PhoneNumber; }
            set
            {
                if (registerModel.PhoneNumber != value)
                {
                    registerModel.PhoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        public bool IsEmailValid
        {
            get { return isEmailValid; }
            set
            {
                if (isEmailValid != value)
                {
                    isEmailValid = value;
                    OnPropertyChanged("IsEmailValid");
                }
            }
        }

        public bool IsPaswordValid
        {
            get { return isEmailValid; }
            set
            {
                if (isEmailValid != value)
                {
                    isEmailValid = value;
                    OnPropertyChanged("IsEmailValid");
                }
            }
        }


        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() => 
                {
                    var isSucces = await apiServices.RegisterAsync(registerModel);
                    if (isSucces)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                });
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
