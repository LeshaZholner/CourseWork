using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WebApp.Client.DI;
using WebApp.Client.Services.AppointmentServices;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Client.Models;

namespace WebApp.Client.ViewModels
{
    public class EditAppointmentViewModel : INotifyPropertyChanged
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();

        public Appointment SelectAppointment { get; set; }

        public EditAppointmentViewModel(Appointment appointment)
        {
            SelectAppointment = appointment;
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
