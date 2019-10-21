using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;

namespace WebApp.BLL.Services.AppointmentService
{
    public interface IAppointmentService
    {
        int MakeAppointment(AppointmentDTO appointmentDTO);
        IEnumerable<AppointmentDTO> GetAppointments();
        void Dispose();
    }
}
