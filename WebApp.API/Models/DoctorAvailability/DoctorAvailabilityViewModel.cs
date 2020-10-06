using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.API.Models.Doctor;

namespace WebApp.API.Models.DoctorAvailability
{
    public class DoctorAvailabilityViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public DateTime DateAvailability { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}