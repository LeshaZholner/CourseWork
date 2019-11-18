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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}