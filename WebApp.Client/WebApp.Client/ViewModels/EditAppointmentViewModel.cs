using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services.AppointmentServices;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Client.Models.Appointment;
using System.Runtime.CompilerServices;
using WebApp.Client.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace WebApp.Client.ViewModels
{
    public class EditAppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();


        private AppointmentCreate appointment;
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

        private ObservableCollection<TimeInterval> timeDoctorAvailability;
        public ObservableCollection<TimeInterval> TimeDoctorAvailability
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

        private TimeInterval selectTime;
        public TimeInterval SelectTime
        {
            get { return selectTime; }
            set
            {
                selectTime = value;
                OnPropertChanged("SelectTime");
            }
        }
        public EditAppointmentViewModel(AppointmentView appointment, List<DoctorAvailabilityView> doctorAvailabilities)
        {
            this.appointment = new AppointmentCreate();
            this.appointment.Id = appointment.Id;
            this.appointment.DoctorId = appointment.DoctorId;

            DoctorAvailabilityViews = new ObservableCollection<DoctorAvailabilityView>(doctorAvailabilities);
        }


        public ICommand GetTimeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var timeInterval = new TimeInterval();
                    timeInterval.TimeFrom = selectDoctorAvailabilityView.TimeFrom;
                    timeInterval.TimeTo = selectDoctorAvailabilityView.TimeTo;
                    var times = timeInterval.GetRangeTime(new TimeSpan(0, 30, 0));
                    var app = await appointmentServices.GetAppointmentAsync(appointment.DoctorId, SelectDoctorAvailabilityView.DateAvailability);
                    times.RemoveAll(t => app.Select(a => a.TimeFrom).Contains(t.TimeFrom));

                    TimeDoctorAvailability = new ObservableCollection<TimeInterval>(times);
                });
            }
        }

        public ICommand SaveAppointmentCommand
        {
            get
            {
                return new Command(async () => {
                    appointment.DateAppointment = SelectDoctorAvailabilityView.DateAvailability;
                    appointment.TimeFrom = SelectTime.TimeFrom;
                    appointment.TimeTo = SelectTime.TimeTo;
                    await appointmentServices.UpdateAppointmentment(appointment);
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
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
