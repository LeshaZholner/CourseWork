using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.DoctorServices
{
    public interface IDoctorServices
    {
        Task<List<Doctor>> GetDoctorsAsync(int? id);
    }
}
