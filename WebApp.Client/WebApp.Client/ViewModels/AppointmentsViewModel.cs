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
using WebApp.Client.Services.DoctorServices;
using WebApp.Client.Services.SpecializationServices;

namespace WebApp.Client.ViewModels
{
    public class AppointmentsViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();
        private ISpecializationServices specializationServices = Bootstrap.ServiceProvider.GetService<ISpecializationServices>();
        private ObservableCollection<Appointment> _appointments;
        private ObservableCollection<AppointmentView> _appointmentsView;

        public AppointmentsViewModel(List<Appointment> appointments)
        {
            _appointments = new ObservableCollection<Appointment>(appointments);
        }

        public ObservableCollection<Appointment> Appointments 
        {
            get { return _appointments; }
            set {
                _appointments = value;
                OnPropertChanged("Appointments");
            } 
        }

        public ObservableCollection<AppointmentView> AppointmentViews
        {
            get 
            {
                var appointmentsView = new ObservableCollection<AppointmentView>();
                foreach (var appointment in _appointments)
                {
                    AppointmentView appointmentView = new AppointmentView();
                    //var doctor = doctorServices.GetDoctorAsync(appointment.DoctorId).Result;
                    //appointmentView.DoctorName = doctor.FirstName + " " + doctor.SecondName;
                    //var specialization = specializationServices.GetSpecializationAsync(doctor.SpecializationId).Result;
                    //appointmentView.DoctorSpecialization = specialization.Name;
                    appointmentView.DoctorName = "Name";
                    appointmentView.DoctorSpecialization = "test";
                    appointmentView.DateAppointment = $"Date {appointment.DateAppointment.ToShortDateString()} from {appointment.TimeFrom} to {appointment.TimeTo}";
                    appointmentsView.Add(appointmentView);
                }
                return appointmentsView;
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
                    Appointment appointment = item as Appointment;
                    await appointmentServices.DeleteAppointmentAsync(appointment.Id);
                    _appointments.Remove(appointment);
                });
            }
        }

        public ICommand EditAppointmentCommand
        {
            get
            {
                return new Command(async (item) =>
                {
                    Appointment appointment = item as Appointment;
                    await Application.Current.MainPage.Navigation.PushAsync(new EditAppointmentPage(appointment));
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
