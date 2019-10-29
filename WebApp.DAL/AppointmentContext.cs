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
        public virtual DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasRequired(d => d.Specialization)
                .WithMany(s => s.Doctors)
                .HasForeignKey(d => d.SpecializationId);

            modelBuilder.Entity<Doctor>().Property(d => d.FirstName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.SecondName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.SpecializationId).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.PhoneNumber).IsRequired();

            modelBuilder.Entity<Appointment>()
                .HasRequired(d => d.Doctor)
                .WithMany(s => s.Appointments)
                .HasForeignKey(d => d.DoctorID);

            modelBuilder.Entity<Appointment>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.LastName).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.PhoneNumber).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.DateAppointment).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.TimeFrom).IsRequired();
            modelBuilder.Entity<Appointment>().Property(a => a.TimeTo).IsRequired();

            modelBuilder.Entity<Specialization>().Property(a => a.Name).IsRequired();


            
        }

    }
}