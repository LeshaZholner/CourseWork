using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models.Appointment
{
    public class AppointmentCreate
    {
        public int? Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateAppointment { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
    }
}

