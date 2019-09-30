using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MobileContext mobileContext;
        private IRepository<Phone> phoneRepository;
        private IRepository<Order> orderRepository;

        private bool disposed = false;

        public IRepository<Phone> Phones
        {
            get { return phoneRepository; }
        }

        public IRepository<Order> Orders
        {
            get { return orderRepository; }
        }

        public UnitOfWork(string connectionString)
        {
            mobileContext = new MobileContext(connectionString);
            phoneRepository = new PhoneRepository(mobileContext);
            orderRepository = new OrderRepositories(mobileContext);
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
                    mobileContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            mobileContext.SaveChanges();
        }
    }
}
