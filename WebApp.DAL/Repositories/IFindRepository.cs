using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DAL.Repositories
{
    public interface IFindRepository<T> : IRepository<T>
    {
        IEnumerable<T> Find(string userId);
    }
}
