using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.DI;
using WebApp.Client.Models;
using WebApp.Client.Services.AppointmentServices;
using WebApp.Client.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApp.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAppointmentPage : ContentPage
    {
        private Appointment appointment;

        public EditAppointmentPage()
        {
            InitializeComponent();
        }

        public EditAppointmentPage(Appointment appointment) : this()
        {
            //this.appointment = appointment;
            BindingContext = new EditAppointmentViewModel(appointment);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}