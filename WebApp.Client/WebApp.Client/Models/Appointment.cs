using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models
{
    public class Appointment
    {
        public string PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
