using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private AppointmentContext context;

        public DoctorRepository(AppointmentContext context)
        {
            this.context = context;
        }

        public void Create(Doctor item)
        {
            context.Doctors.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            context.Doctors.Remove(item);
        }

        public IEnumerable<Doctor> Find(Func<Doctor, bool> predicate)
        {
            return context.Doctors.Where(predicate).ToList();
        }

        public Doctor Get(int id)
        {
            var item = context.Doctors.Find(id);
            return item != null ? item : throw new Exception($"Doctor {id} not found");  
        }

        public IEnumerable<Doctor> GetAll()
        {
            return context.Doctors.ToList();
        }

        public void Update(Doctor item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
