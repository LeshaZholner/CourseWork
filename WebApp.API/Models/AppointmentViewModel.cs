using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.API.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}