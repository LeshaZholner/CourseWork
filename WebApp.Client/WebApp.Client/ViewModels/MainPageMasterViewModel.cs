using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services;
using WebApp.Client.Views;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Client.ViewModels
{
    public class MainPageMasterViewModel : INotifyPropertyChanged
    {
        private IApiServices apiServices = Bootstrap.ServiceProvider.GetService<IApiServices>();

        public ObservableCollection<MainPageMasterMenuItem> MenuItems { get; set; }
        public MainPageMasterMenuItem SelectItem { get; set; }

        public MainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainPageMasterMenuItem>(new[]
            {
                    new MainPageMasterMenuItem { Id = 0, Title = "Account", TargetType = typeof(UserInfoPage), Icon="\uf007" },
                    new MainPageMasterMenuItem { Id = 1, Title = "Appointments", TargetType = typeof(AppointmentsPage), Icon="\uf46d" },
                    new MainPageMasterMenuItem { Id = 2, Title = "Logout", TargetType = typeof(LoginPage), Icon="\uf2f5" }
                });
        }

        public ICommand SetPageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var page = (Page)Activator.CreateInstance(SelectItem.TargetType);
                    page.Title = SelectItem.Title;

                    if(page is LoginPage p)
                    {
                        await apiServices.LogoutUserAsync();
                        App.Current.MainPage = new NavigationPage(page);
                    }
                    else
                    {
                        var navigationPage = (NavigationPage)(Application.Current.MainPage);
                        var masterPage = (MainPage)(navigationPage.RootPage);

                        masterPage.Detail = new NavigationPage(page);
                        masterPage.IsPresented = false;
                    }
                });
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
