namespace WebApp.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApp.DAL.Entities;

    public class AppointmentContext : DbContext
    {
        public AppointmentContext(string connectionString)
            : base(connectionString)
        {
        }

        public AppointmentContext()
        {

        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

    }
}