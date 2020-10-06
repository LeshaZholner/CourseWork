using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.DAL.Entities;
using WebApp.DAL.UoW;

namespace WebApp.BLL.Services.DoctorAvailabilityService
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private IUnitOfWork Database { get; set; }

        public DoctorAvailabilityService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<DoctorAvailabilityDTO> GetDoctorAvailabilitys(int doctorId)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorAvailability, DoctorAvailabilityDTO>();
                cfg.CreateMap<Doctor, DoctorDTO>();
                cfg.CreateMap<Specialization, SpecializationDTO>();
            }).CreateMapper();

            return mapper.Map<IEnumerable<DoctorAvailability>, List<DoctorAvailabilityDTO>>(Database.DoctorAvailability.Find(d => d.DoctorId == doctorId));
        }
    }
}
