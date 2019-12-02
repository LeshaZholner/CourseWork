using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.API.Models.Doctor;

namespace WebApp.API.Models.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorViewModel Doctor { get;set;}
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}