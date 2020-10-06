using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.DoctorAvailabilityServices
{
    interface IDoctorAvailabilityService
    {
        Task<List<DoctorAvailabilityView>> GetDoctorAvailabilitiesAsync(int id);
    }
}
