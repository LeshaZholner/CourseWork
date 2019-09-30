using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;

namespace WebApp.BLL.Services
{
    public interface IAppointmentService
    {
        void MakeAppointment(AppointmentDTO appointmentDTO);
        IEnumerable<DoctorDTO> GetDoctors();
        DoctorDTO GetDoctor(int? id);
        void Dispose();
    }
}
