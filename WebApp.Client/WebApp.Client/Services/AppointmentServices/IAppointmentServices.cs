using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models.Appointment;

namespace WebApp.Client.Services.AppointmentServices
{
    public interface IAppointmentServices
    {
        Task<bool> MakeAppointmentAsync(AppointmentCreate appointment);
        Task<bool> DeleteAppointmentAsync(int id);
        Task<List<AppointmentView>> GetAppointmentAsync();
        Task<List<AppointmentView>> GetAppointmentAsync(int doctorId, DateTime date);
        Task<bool> UpdateAppointmentment(AppointmentCreate appointment);
    }
}
