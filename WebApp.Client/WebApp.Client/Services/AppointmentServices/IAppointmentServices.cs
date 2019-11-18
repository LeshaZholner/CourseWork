﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.AppointmentServices
{
    public interface IAppointmentServices
    {
        Task<bool> MakeAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(int id);
        Task<List<Appointment>> GetAppointmentAsync();
        Task<bool> UpdateAppointmentment(Appointment appointment);
    }
}
