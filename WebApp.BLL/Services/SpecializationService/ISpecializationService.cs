using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.DAL.Entities;

namespace WebApp.BLL.Services.SpecializationService
{
    public interface ISpecializationService
    {
        IEnumerable<SpecializationDTO> GetSpecializations();
        IEnumerable<SpecializationDTO> GetSpecializations(Func<SpecializationDTO, bool> predicate);
        SpecializationDTO GetSpecialization(int? id);
        void AddSpecialization(SpecializationDTO specialization);
        void Dispose();
    }
}
