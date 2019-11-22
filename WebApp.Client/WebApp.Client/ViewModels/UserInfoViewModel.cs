﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.Models;
using WebApp.Client.Views;
using Xamarin.Forms;

namespace WebApp.Client.ViewModels
{
    public class UserInfoViewModel
    {
        public UserInfo UserInfo { get; set; }

        public UserInfoViewModel(UserInfo userInfo)
        {
            UserInfo = userInfo;
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ChangePasswordPage());
                });
            }
        }
    }
}