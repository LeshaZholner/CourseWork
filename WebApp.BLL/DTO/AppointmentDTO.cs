using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.BLL.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}
