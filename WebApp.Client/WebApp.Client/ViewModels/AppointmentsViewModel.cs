using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Models;
using WebApp.Client.Services.AppointmentServices;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WebApp.Client.Views;

namespace WebApp.Client.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private List<Appointment> _appointments;
     
        public AppointmentsViewModel(List<Appointment> appointments)
        {
            _appointments = appointments;
        }

        public List<Appointment> Appointments 
        {
            get { return _appointments; }
            set {
                _appointments = value;
                OnPropertChanged();
            } 
        }

        public ICommand GetAppointmentsCommand
        {
            get
            {
                return new Command(async () => {
                    Appointments = await appointmentServices.GetAppointmentAsync();
                });
            }
        }

        public ICommand MakeAppointmentCommand
        {
            get
            {
                return new Command(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new MakeAppointmentPage());
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
