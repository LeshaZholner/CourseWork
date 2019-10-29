using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.DI;
using WebApp.Client.Services.DoctorServices;
using WebApp.Client.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApp.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeAppointmentPage : ContentPage
    {
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();

        public MakeAppointmentPage()
        {
            InitializeComponent();

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var doctors = await doctorServices.GetDoctorsAsync();
            BindingContext = new MakeAppointmentViewModel(doctors);
        }
    }
}