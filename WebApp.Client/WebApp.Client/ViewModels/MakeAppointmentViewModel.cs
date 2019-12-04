using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Models;
using WebApp.Client.Services.AppointmentServices;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using WebApp.Client.Services.DoctorServices;
using System.Collections.ObjectModel;
using WebApp.Client.Services;
using WebApp.Client.Models.Appointment;
using WebApp.Client.Models.Doctor;

namespace WebApp.Client.ViewModels
{
    public class MakeAppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();
        private IApiServices apiServices = Bootstrap.ServiceProvider.GetService<IApiServices>();

        public int DoctorId { get; set; }
        public DateTime DateAppointment { get; set; } = DateTime.Now;
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }


        private List<Specialization> specializations;
        private Specialization selectSpecialization;
        public List<Specialization> Specializations
        {
            get { return specializations; }
            set
            {
                specializations = value;
                OnPropertChanged("Specializations");
            }
        }
        public Specialization SelectSpecialization
        {
            get { return selectSpecialization; }
            set
            {
                selectSpecialization = value;
                OnPropertChanged("SelectSpecialization");
            }
        }


        private ObservableCollection<DoctorView> doctors;
        private DoctorView selectDoctor;
        public ObservableCollection<DoctorView> Doctors 
        {
            get { return doctors; }
            set
            {
                doctors = value;
                OnPropertChanged("Doctors");
            }
        }
        public DoctorView SelectDoctor 
        {
            get { return selectDoctor; }
            set
            {
                selectDoctor = value;
                OnPropertChanged("SelectDoctor");
            }
        }


        
        public MakeAppointmentViewModel(List<Specialization> specializations)
        {
            this.specializations = specializations;
        }

        public ICommand GetDoctorsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Doctors = new ObservableCollection<DoctorView>(await doctorServices.GetDoctorsAsync(selectSpecialization.Id));
                });
            }
        }

        public ICommand MakeAppointmentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userInfo = await apiServices.UserInfoAsync();
                    var appointment = new AppointmentCreate()
                    {
                        DoctorId = selectDoctor.Id,
                        DateAppointment = DateAppointment,
                        TimeTo = TimeTo,
                        TimeFrom = TimeFrom,
                    };
                    await appointmentServices.MakeAppointmentAsync(appointment);
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
