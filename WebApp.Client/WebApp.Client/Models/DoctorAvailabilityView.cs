using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Client.Models.Doctor;

namespace WebApp.Client.Models
{
    public class DoctorAvailabilityView
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorView Doctor { get; set; }
        public DateTime DateAvailability { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}
