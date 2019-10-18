using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models
{
    public class Appointment
    {
        public string PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

