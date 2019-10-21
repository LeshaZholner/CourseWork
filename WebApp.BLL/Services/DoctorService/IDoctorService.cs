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
        IEnumerable<DoctorDTO> GetDoctors(Func<DoctorDTO, bool> predicate);
        DoctorDTO GetDoctor(int id);
        int AddDoctor(DoctorDTO doctor);
        void Dispose();
    }
}
