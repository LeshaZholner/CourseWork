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

namespace WebApp.Client.ViewModels
{
    public class EditAppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();

        public AppointmentCreate SelectAppointment { get; set; }

        public EditAppointmentViewModel(AppointmentView appointment)
        {
            SelectAppointment = new AppointmentCreate();
            SelectAppointment.Id = appointment.Id;
            SelectAppointment.DoctorId = appointment.DoctorId;
            SelectAppointment.DateAppointment = appointment.DateAppointment;
            SelectAppointment.TimeFrom = appointment.TimeFrom;
            SelectAppointment.TimeTo = appointment.TimeTo;
        }

        public ICommand SaveAppointmentCommand
        {
            get
            {
                return new Command(async () => {
                    await appointmentServices.UpdateAppointmentment(SelectAppointment);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
