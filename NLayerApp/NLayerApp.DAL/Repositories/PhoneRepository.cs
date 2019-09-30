using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private MobileContext mobileContext;

        public PhoneRepository(MobileContext mobileContext)
        {
            this.mobileContext = mobileContext;
        }

        public void Create(Phone item)
        {
            mobileContext.Phones.Add(item);
        }

        public void Delete(int id)
        {
            var phone = Get(id);
            mobileContext.Phones.Remove(phone);
        }

        public IEnumerable<Phone> Find(Func<Phone, bool> predicate)
        {
            return mobileContext.Phones.Where(predicate);
        }

        public Phone Get(int id)
        {
            var phone = mobileContext.Phones.Find(id);
            return phone != null ? phone : throw new Exception($"Phone '{id}' not found");
        }

        public IEnumerable<Phone> GetAll()
        {
            return mobileContext.Phones.AsEnumerable();
        }

        public void Update(Phone item)
        {
            mobileContext.Entry(item).State = EntityState.Modified;
        }
    }
}
