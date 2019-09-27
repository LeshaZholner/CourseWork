using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;
using WebApp.DAL.Repositories;

namespace WebApp.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppointmentContext context;
        private IRepository<Doctor> _doctors;
        private IRepository<Appointment> _appointment;

        private bool disposed = false;

        public IRepository<Doctor> Doctors => _doctors;
        public IRepository<Appointment> Appointments => _appointment;

        public UnitOfWork(string connectionString)
        {
            this.context = new AppointmentContext(connectionString);
            _doctors = new DoctorRepository(context);
            _appointment = new AppointmentRepository(context);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
