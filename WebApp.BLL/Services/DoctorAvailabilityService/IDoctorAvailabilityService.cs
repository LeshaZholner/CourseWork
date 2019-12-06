using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;

namespace WebApp.BLL.Services.DoctorAvailabilityService
{
    public interface IDoctorAvailabilityService
    {
        IEnumerable<DoctorAvailabilityDTO> GetDoctorAvailabilitys(string userId);
        void Dispose();
    }
}
