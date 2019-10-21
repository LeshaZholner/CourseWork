using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Repositories
{
    class SpecializationRepository : IRepository<Specialization>
    {
        private AppointmentContext context;

        public SpecializationRepository(AppointmentContext context)
        {
            this.context = context;
        }
        public int Create(Specialization item)
        {
            var specializationEntity = context.Specializations.Add(item);
            context.SaveChanges();
            return specializationEntity.Id;
        }

        public void Delete(int id)
        {
            var spec = Get(id);
            context.Specializations.Remove(spec);
        }

        public IEnumerable<Specialization> Find(Func<Specialization, bool> predicate)
        {
            return context.Specializations.Where(predicate).ToList();
        }

        public Specialization Get(int id)
        {
            return context.Specializations.Find(id); 
        }

        public IEnumerable<Specialization> GetAll()
        {
            return context.Specializations.ToList();
        }

        public void Update(Specialization item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
