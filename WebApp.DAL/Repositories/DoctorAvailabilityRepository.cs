using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;
using System.Data.Entity;

namespace WebApp.DAL.Repositories
{
    public class DoctorAvailabilityRepository : IFindRepository<DoctorAvailability>
    {
        private AppointmentContext context;

        public DoctorAvailabilityRepository(AppointmentContext context)
        {
            this.context = context;
        }

        public int Create(DoctorAvailability item)
        {
            var doctorAvailability =  context.DoctorAvailability.Add(item);
            context.SaveChanges();
            return doctorAvailability.Id;
        }

        public void Delete(int id)
        {
            var item = Get(id);
            context.DoctorAvailability.Remove(item);
            context.SaveChanges();
        }

        public DoctorAvailability Get(int id)
        {
            return context.DoctorAvailability.Where(d => d.Id == id).Include(d => d.Doctor).Include("Doctor.Specialization").FirstOrDefault();
        }

        public IEnumerable<DoctorAvailability> Find(Func<DoctorAvailability,bool> predicate)
        {
            return context.DoctorAvailability.Where(predicate).AsQueryable().Include(d => d.Doctor).Include("Doctor.Specialization");
        }

        public IEnumerable<DoctorAvailability> GetAll()
        {
            return context.DoctorAvailability.Include(d => d.Doctor).Include("Doctor.Specialization");
        }

        public void Update(DoctorAvailability item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
