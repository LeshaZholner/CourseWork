using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WebApp.Client.Views;
using Xamarin.Forms;

namespace WebApp.Client.ViewModels
{
    public class MainPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainPageMasterMenuItem> MenuItems { get; set; }

        public MainPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MainPageMasterMenuItem>(new[]
            {
                    new MainPageMasterMenuItem { Id = 0, Title = "Account", TargetType = typeof(UserInfoPage) },
                    new MainPageMasterMenuItem { Id = 1, Title = "Appointments", TargetType = typeof(AppointmentsPage) },
                    new MainPageMasterMenuItem { Id = 2, Title = "Logout" }
                });
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
