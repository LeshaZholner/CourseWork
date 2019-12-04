using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.BLL.Infrastructure;
using WebApp.DAL.Entities;
using WebApp.DAL.UoW;

namespace WebApp.BLL.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork Database { get; set; }

        public DoctorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public DoctorDTO GetDoctor(int id)
        {
            var doctor = Database.Doctors.Get(id);
            if (doctor == null)
            {
                return null;
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<Doctor, DoctorDTO>(doctor);
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Doctor, DoctorDTO>();
                cfg.CreateMap<Specialization, SpecializationDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }

        public IEnumerable<DoctorDTO> GetDoctors(Func<DoctorDTO, bool> predicate)
        {
            return GetDoctors().Where(predicate);
        }
        public int AddDoctor(DoctorDTO doctor)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, Doctor>()).CreateMapper();
            return Database.Doctors.Create(mapper.Map<DoctorDTO, Doctor>(doctor));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
