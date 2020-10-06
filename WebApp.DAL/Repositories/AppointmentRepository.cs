using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;
using System.Data.Entity;

namespace WebApp.DAL.Repositories
{
    public class AppointmentRepository : IFindRepository<Appointment>
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
            return context.Appointments.Where(predicate).AsQueryable().Include(a => a.Doctor).Include("Doctor.Specialization").ToList();
        }

        public Appointment Get(int id)
        {
            var appointment = context.Appointments.Where(a => a.Id == id).Include(a => a.Doctor).Include("Doctor.Specialization").FirstOrDefault();
            return appointment;
        }

        public IEnumerable<Appointment> GetAll()
        {
            var apps = context.Appointments.Include(a => a.Doctor).Include("Doctor.Specialization").ToList();
            return apps;
        }

        public void Update(Appointment item)
        {
            var appointment = context.Appointments.Find(item.Id);
            if(appointment != null)
            {
                context.Entry(appointment).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}
