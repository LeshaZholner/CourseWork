using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Repositories
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private AppointmentContext context;

        public AppointmentRepository(AppointmentContext context)
        {
            this.context = context;
        }
        public int Create(Appointment item)
        {
            var appointmentEntity = context.Appointments.Add(item);
            context.SaveChanges();
            return appointmentEntity.Id;
        }

        public void Delete(int id)
        {
            var item = Get(id);
            context.Appointments.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<Appointment> Find(Func<Appointment, bool> predicate)
        {
            return context.Appointments.Where(predicate).ToList();
        }

        public Appointment Get(int id)
        {
            return context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public void Update(Appointment item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
