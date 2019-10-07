using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.BLL.Infrastructure;
using WebApp.DAL.Entities;
using WebApp.DAL.UoW;

namespace WebApp.BLL.Services.SpecializationService
{
    public class SpecializationService : ISpecializationService
    {
        private IUnitOfWork Database { get; set; }

        public SpecializationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SpecializationDTO> GetSpecializations()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Specialization, SpecializationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Specialization>, List<SpecializationDTO>>(Database.Specializations.GetAll());
        }

        public IEnumerable<SpecializationDTO> GetSpecializations(Func<SpecializationDTO, bool> predicate)
        {
            return GetSpecializations().Where(predicate);
        }

        public SpecializationDTO GetSpecialization(int? id)
        {
            if (id == null)
            {
                throw new ValidationException($"Incorrect id", "");
            }
            var specialization = Database.Specializations.Get(id.Value);
            if (specialization == null)
            {
                throw new ValidationException($"specialization {id} not found", "");
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Specialization, SpecializationDTO>()).CreateMapper();
            return mapper.Map<Specialization, SpecializationDTO>(Database.Specializations.Get(id.Value));
        }

        public void AddSpecialization(SpecializationDTO specialization)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SpecializationDTO, Specialization>()).CreateMapper();
            Database.Specializations.Create(mapper.Map<SpecializationDTO, Specialization>(specialization));
            Database.Save();
        }
    }
}
