using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.DI;
using WebApp.Client.Models;
using WebApp.Client.Models.Appointment;
using WebApp.Client.Services.AppointmentServices;
using WebApp.Client.Services.DoctorAvailabilityServices;
using WebApp.Client.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApp.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAppointmentPage : ContentPage
    {
        public EditAppointmentPage()
        {
            InitializeComponent();
        }

        public EditAppointmentPage(AppointmentView appointment, List<DoctorAvailabilityView> doctorAvailabilities) : this()
        {
              BindingContext = new EditAppointmentViewModel(appointment, doctorAvailabilities);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}