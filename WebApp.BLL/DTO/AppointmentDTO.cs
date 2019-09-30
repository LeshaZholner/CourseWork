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
        public string NumberPhone { get; set; }
        public int DoctorID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
