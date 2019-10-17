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

namespace WebApp.Client.ViewModels
{
    public class MakeAppointmentViewModel : INotifyPropertyChanged
    {
        public string PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();

        public ICommand MakeAppointmentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var appointment = new Appointment()
                    {
                        DoctorId = this.DoctorId,
                        PhoneNumber = this.PhoneNumber,
                        DateFrom = this.DateFrom,
                        DateTo = this.DateTo
                    };
                    await appointmentServices.MakeAppointmentAsync(appointment);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
