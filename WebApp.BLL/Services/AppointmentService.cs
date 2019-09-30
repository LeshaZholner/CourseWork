using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.BLL.Infrastructure;
using WebApp.DAL.Entities;
using WebApp.DAL.UoW;

namespace WebApp.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {

        private IUnitOfWork Database { get; set; }

        //public AppointmentService(IUnitOfWork uow)
        //{
        //    Database = uow;
        //}

        public AppointmentService(string connectionString)
        {
            Database = new UnitOfWork(connectionString);
        }


        public void Dispose()
        {
            Database.Dispose();
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

        public void MakeAppointment(AppointmentDTO appointmentDTO)
        {
            var doctor = Database.Doctors.Get(appointmentDTO.DoctorID);
            if (doctor == null)
            {
                throw new ValidationException($"Doctor {appointmentDTO.DoctorID} not found", "");
            }
            var appointment = new Appointment
            {
                NumberPhone = appointmentDTO.NumberPhone,
                DoctorID = appointmentDTO.DoctorID,
                DateFrom = appointmentDTO.DateFrom,
                DateTo = appointmentDTO.DateTo,
            };
            Database.Appointments.Create(appointment);
            Database.Save();
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Doctor, DoctorDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Doctor>, List<DoctorDTO>>(Database.Doctors.GetAll());
        }
    }
}
