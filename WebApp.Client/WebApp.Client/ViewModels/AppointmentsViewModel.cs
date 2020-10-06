using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services.AppointmentServices;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WebApp.Client.Views;
using System.Linq;
using System.Collections.ObjectModel;
using WebApp.Client.Services.DoctorServices;
using WebApp.Client.Services.SpecializationServices;
using WebApp.Client.Models.Appointment;
using WebApp.Client.Services.DoctorAvailabilityServices;

namespace WebApp.Client.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();
        private ISpecializationServices specializationServices = Bootstrap.ServiceProvider.GetService<ISpecializationServices>();
        private IDoctorAvailabilityService doctorAvailabilityServices = Bootstrap.ServiceProvider.GetService<IDoctorAvailabilityService>();

        private ObservableCollection<AppointmentView> _appointmentsView;

        public AppointmentsViewModel(List<AppointmentView> appointments)
        {
            _appointmentsView = new ObservableCollection<AppointmentView>(appointments);
        }

        public ObservableCollection<AppointmentView> AppointmentsView 
        {
            get { return _appointmentsView; }
            set {
                _appointmentsView = value;
                OnPropertChanged("Appointments");
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

        public ICommand RamoveAppointmentCommand
        {
            get
            {
                return new Command(async (item) => {
                    AppointmentView appointment = item as AppointmentView;
                    await appointmentServices.DeleteAppointmentAsync(appointment.Id);
                    _appointmentsView.Remove(appointment);
                });
            }
        }

        public ICommand EditAppointmentCommand
        {
            get
            {
                return new Command(async (item) =>
                {
                    AppointmentView appointment = item as AppointmentView;
                    var doctorAvailability = await doctorAvailabilityServices.GetDoctorAvailabilitiesAsync(appointment.DoctorId);
                    await Application.Current.MainPage.Navigation.PushAsync(new EditAppointmentPage(appointment, doctorAvailability));
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
