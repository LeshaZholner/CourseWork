﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using WebApp.Client.Services;
using WebApp.Client.Services.AppointmentServices;
using WebApp.Client.Services.DoctorAvailabilityServices;
using WebApp.Client.Services.DoctorServices;
using WebApp.Client.Services.SpecializationServices;

namespace WebApp.Client.DI
{
    public static class Bootstrap
    {
        public static ServiceProvider ServiceProvider = new ServiceCollection()
            .AddScoped<IApiServices, ApiServices>(i => new ApiServices())
            .AddScoped<IAppointmentServices, AppointmentServices>(i => new AppointmentServices())
            .AddScoped<IDoctorServices, DoctorServices>(i => new DoctorServices())
            .AddScoped<ISpecializationServices, SpecializationServices>(i => new SpecializationServices())
            .AddScoped<IDoctorAvailabilityService, DoctorAvailabilityService>(i => new DoctorAvailabilityService())
            .BuildServiceProvider();
    }
}
