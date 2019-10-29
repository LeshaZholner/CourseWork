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
    public partial class AppointmentsPage : ContentPage
    {
        private IAppointmentServices appointmentServices = Bootstrap.ServiceProvider.GetService<IAppointmentServices>();
        public AppointmentsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var appointments = await appointmentServices.GetAppointmentAsync();
            BindingContext = new AppointmentsViewModel(appointments);
        }
    }
}