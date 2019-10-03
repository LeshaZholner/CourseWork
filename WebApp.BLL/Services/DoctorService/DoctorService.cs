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

        public DoctorDTO GetDoctor(int? id)
        {
            if (id == null)
            {
                throw new ValidationException($"Incorrect id", "");
            }
            var doctor = Database.Doctors.Get(id.Value);
            if (doctor == null)
            {
                throw new ValidationException($"Doctor {id} not found", "");
            }
            return new DoctorDTO { Id = doctor.Id, FirstName = doctor.FirstName, SecondName = doctor.SecondName };
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
