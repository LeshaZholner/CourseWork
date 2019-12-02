using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.API.Models.Appointment
{
    public class AppointmentCreateModel
    {
        public int DoctorId { get; set; }
        [Required]
        public DateTime DateAppointment { get; set; }
        [Required]
        public TimeSpan TimeFrom { get; set; }
        [Required]
        public TimeSpan TimeTo { get; set; }
    }
}