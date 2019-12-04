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
        private IFindRepository<Appointment> _appointment;
        private IRepository<Specialization> _specializations;

        private bool disposed = false;

        public IRepository<Doctor> Doctors => _doctors;
        public IFindRepository<Appointment> Appointments => _appointment;
        public IRepository<Specialization> Specializations => _specializations;

        public UnitOfWork(string connectionString)
        {
            this.context = new AppointmentContext(connectionString);
            _doctors = new DoctorRepository(context);
            _appointment = new AppointmentRepository(context);
            _specializations = new SpecializationRepository(context);
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
