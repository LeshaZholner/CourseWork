using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;

namespace WebApp.BLL.Services.DoctorService
{
    public interface IDoctorService
    {
        IEnumerable<DoctorDTO> GetDoctors();
        DoctorDTO GetDoctor(int? id);
        void Dispose();
    }
}
