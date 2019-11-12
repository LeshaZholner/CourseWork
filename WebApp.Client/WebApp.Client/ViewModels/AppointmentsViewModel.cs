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
using System.Linq;
using System.Collections.ObjectModel;

namespace WebApp.Client.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private ObservableCollection<Appointment> _appointments;
     
        public AppointmentsViewModel(List<Appointment> appointments)
        {
            _appointments = new ObservableCollection<Appointment>(appointments);
        }

        public ObservableCollection<Appointment> Appointments 
        {
            get { return _appointments; }
            set {
                _appointments = value;
                OnPropertChanged();
            } 
        }

        //public ICommand GetAppointmentsCommand
        //{
        //    get
        //    {
        //        return new Command(async () => {
        //            var response = await appointmentServices.GetAppointmentAsync();
        //            Appointments = new ObservableCollection<Appointment>(response);
        //        });
        //    }
        //}

        public ICommand MakeAppointmentCommand
        {
            get
            {
                return new Command(async () => {
                    await Application.Current.MainPage.Navigation.PushAsync(new MakeAppointmentPage());
                });
            }
        }

        public ICommand RamoveAppointmentCommand
        {
            get
            {
                return new Command(async (item) => {
                    Appointment appointment = item as Appointment;
                    await appointmentServices.DeleteAppointmentAsync(appointment.Id);
                    _appointments.Remove(appointment);
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
