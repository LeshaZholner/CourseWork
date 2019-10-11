using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WebApp.Client.Services;
using WebApp.Client.Services.AppointmentServices;

namespace WebApp.Client.DI
{
    public static class Bootstrap
    {
        public static ServiceProvider ServiceProvider = new ServiceCollection()
            .AddScoped<IApiServices, ApiServices>(i => new ApiServices())
            .AddScoped<IAppointmentServices, AppointmentServices>(i => new AppointmentServices())
            .BuildServiceProvider();
    }
}
