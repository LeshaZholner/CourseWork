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
using WebApp.Client.Services.DoctorAvailabilityServices;

namespace WebApp.Client.ViewModels
{
    public class MakeAppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();
        private IApiServices apiServices = Bootstrap.ServiceProvider.GetService<IApiServices>();
        private IDoctorAvailabilityService doctorAvailabilityServices = Bootstrap.ServiceProvider.GetService<IDoctorAvailabilityService>();
        public int DoctorId { get; set; }

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
        public ObservableCollection<DoctorView> Doctors
        {
            get { return doctors; }
            set
            {
                doctors = value;
                OnPropertChanged("Doctors");
            }
        }

        private DoctorView selectDoctor;
        public DoctorView SelectDoctor 
        {
            get { return selectDoctor; }
            set
            {
                selectDoctor = value;
                OnPropertChanged("SelectDoctor");
            }
        }

        private ObservableCollection<DoctorAvailabilityView> doctorAvailabilityViews;
        public ObservableCollection<DoctorAvailabilityView> DoctorAvailabilityViews
        {
            get { return doctorAvailabilityViews; }
            set
            {
                doctorAvailabilityViews = value;
                OnPropertChanged("DoctorAvailabilityViews");
            }
        }

        private DoctorAvailabilityView selectDoctorAvailabilityView;
        public DoctorAvailabilityView SelectDoctorAvailabilityView
        {
            get { return selectDoctorAvailabilityView; }
            set
            {
                selectDoctorAvailabilityView = value;
                OnPropertChanged("SelectDoctorAvailabilityView");
            }
        }

        private ObservableCollection<TimeSpan> timeDoctorAvailability;
        public ObservableCollection<TimeSpan> TimeDoctorAvailability
        {
            get
            {
                return timeDoctorAvailability;
            }
            set
            {
                timeDoctorAvailability = value;
                OnPropertChanged("TimeDoctorAvailability");
            }
        }

        private TimeSpan selectTime;
        public TimeSpan SelectTime
        {
            get { return selectTime; }
            set
            {
                selectTime = value;
                OnPropertChanged("SelectTime");
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
        
        public ICommand GetDoctorAvailabilitiesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    DoctorAvailabilityViews = new ObservableCollection<DoctorAvailabilityView>(await doctorAvailabilityServices.GetDoctorAvailabilitiesAsync(selectDoctor.Id));
                });
            }
        }
        

        public ICommand GetTimeCommand
        {
            get
            {
                return new Command(() =>
                {
                    TimeDoctorAvailability = GetRangeTime(selectDoctorAvailabilityView.TimeFrom, selectDoctorAvailabilityView.TimeTo, new TimeSpan(0, 30, 0));
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
                        DateAppointment = selectDoctorAvailabilityView.DateAvailability,
                        TimeTo = selectTime,
                        TimeFrom = selectTime.Add(new TimeSpan(0,30,0)),
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

        private ObservableCollection<TimeSpan> GetRangeTime(TimeSpan timeFrom, TimeSpan timeTo, TimeSpan step)
        {
            var times = new ObservableCollection<TimeSpan>();
            for (int i = 0; timeFrom.Add(TimeSpan.FromTicks(step.Ticks * i)) < timeTo; i++)
            {
                var time = timeFrom.Add(TimeSpan.FromTicks(step.Ticks * i));
                times.Add(time);
            }

            return times;
        }
    }
}
