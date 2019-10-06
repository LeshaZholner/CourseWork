using System;
using WebApp.Client.DI;
using WebApp.Client.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApp.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DiCollection.ServiceCollection.
            MainPage = new NavigationPage(new RegisterPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
