using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Client.Models;

namespace WebApp.Client.Services.SpecializationServices
{
    public interface ISpecializationServices
    {
        Task<List<Specialization>> GetSpecializationsAsync();
        Task<Specialization> GetSpecializationAsync(int id);
    }
}
