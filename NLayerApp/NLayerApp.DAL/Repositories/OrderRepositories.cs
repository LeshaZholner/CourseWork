using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class OrderRepositories : IRepository<Order>
    {
        private MobileContext mobileContext { get; }

        public OrderRepositories(MobileContext mobileContext)
        {
            this.mobileContext = mobileContext;
        }
        public void Create(Order item)
        {
            mobileContext.Orders.Add(item);
        }

        public void Delete(int id)
        {
            var order = Get(id);
            mobileContext.Orders.Remove(order);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return mobileContext.Orders.Include(o => o.Phone).Where(predicate);
        }

        public Order Get(int id)
        {
            var order = mobileContext.Orders.Find(id);
            return order != null ? order : throw new Exception($"Order '{id} not found'");
        }

        public IEnumerable<Order> GetAll()
        {
            return mobileContext.Orders.Include(o => o.Phone);
        }

        public void Update(Order item)
        {
            mobileContext.Entry(item).State = EntityState.Modified;
        }
    }
}
