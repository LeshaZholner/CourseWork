using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.DI;
using WebApp.Client.Services.DoctorServices;
using WebApp.Client.Services.SpecializationServices;
using WebApp.Client.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApp.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeAppointmentPage : ContentPage
    {
        private IDoctorServices doctorServices = Bootstrap.ServiceProvider.GetService<IDoctorServices>();
        private ISpecializationServices specializationServices = Bootstrap.ServiceProvider.GetService<ISpecializationServices>();
        public MakeAppointmentPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var specializations = await specializationServices.GetSpecializationsAsync();
            BindingContext = new MakeAppointmentViewModel(specializations);
        }
    }
}