using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Client.Models.Doctor;

namespace WebApp.Client.Models.Appointment
{
    public class AppointmentView
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorView Doctor { get; set; }
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}
