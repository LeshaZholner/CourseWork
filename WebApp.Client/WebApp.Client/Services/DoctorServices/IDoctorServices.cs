using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models.Doctor;

namespace WebApp.Client.Services.DoctorServices
{
    public interface IDoctorServices
    {
        Task<List<DoctorView>> GetDoctorsAsync(int? id);
        Task<DoctorView> GetDoctorAsync(int id);
    }
}
