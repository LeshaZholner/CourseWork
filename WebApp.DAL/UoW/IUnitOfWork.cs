using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;
using WebApp.DAL.Repositories;

namespace WebApp.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Doctor> Doctors { get; }
        IFindRepository<Appointment> Appointments { get; }
        IRepository<Specialization> Specializations { get; }
        IFindRepository<DoctorAvailability> DoctorAvailability { get; }
        void Save();
    }
}
