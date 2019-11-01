﻿using System;
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

namespace WebApp.Client.ViewModels
{
    public class MakeAppointmentViewModel : INotifyPropertyChanged
    {
        public int DoctorId { get; set; }
        public DateTime DateAppointment { get; set; } = DateTime.Now;
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }

        private List<Doctor> doctors;
        public List<Doctor> Doctors 
        {
            get { return doctors; }
            set
            {
                doctors = value;
                OnPropertChanged();
            }
        }

        private Doctor selectDoctor;
        public Doctor SelectDoctor 
        {
            get { return selectDoctor; }
            set
            {
                selectDoctor = value;
                OnPropertChanged();
            }
        }

        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();
        public MakeAppointmentViewModel(List<Doctor> doctors)
        {
            this.doctors = doctors;
        }

        public ICommand MakeAppointmentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var appointment = new Appointment()
                    {
                        DoctorId = selectDoctor.Id,
                        PhoneNumber = "777-777-8888",
                        DateAppointment = this.DateAppointment,
                        TimeTo = this.TimeTo,
                        TimeFrom = this.TimeFrom,
                        FirstName = "FN",
                        LastName = "LN"
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
