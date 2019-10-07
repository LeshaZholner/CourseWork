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
        public void Create(Specialization item)
        {
            context.Specializations.Add(item);
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
            var spec = context.Specializations.Find(id);
            return spec != null ? spec : throw new Exception($"Specialization {id} not found!"); 
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
