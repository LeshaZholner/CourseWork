using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.BLL.DTO;
using WebApp.BLL.Infrastructure;
using WebApp.DAL.Entities;
using WebApp.DAL.UoW;

namespace WebApp.BLL.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {

        private IUnitOfWork Database { get; set; }

        public AppointmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public int MakeAppointment(AppointmentDTO appointmentDTO)
        {
            var doctor = Database.Doctors.Get(appointmentDTO.DoctorId);
            if (doctor == null)
            {
                throw new ValidationException($"Doctor {appointmentDTO.DoctorId} not found", "");
            }
            var appointment = new Appointment
            {
                UserId = appointmentDTO.UserId,
                DoctorID = appointmentDTO.DoctorId,
                DateAppointment = appointmentDTO.DateAppointment,
                TimeFrom = appointmentDTO.TimeFrom,
                TimeTo = appointmentDTO.TimeTo
            };
            return Database.Appointments.Create(appointment);
        }

        public IEnumerable<AppointmentDTO> GetAppointments(string userId)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Appointment, AppointmentDTO>();
                cfg.CreateMap<Doctor, DoctorDTO>();
                cfg.CreateMap<Specialization, SpecializationDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Appointment>, List<AppointmentDTO>>(Database.Appointments.Find(userId));
        }
        public AppointmentDTO GetAppointment(int id)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Appointment, AppointmentDTO>();
                cfg.CreateMap<Doctor, DoctorDTO>();
                cfg.CreateMap<Specialization, SpecializationDTO>();
            }).CreateMapper();
            return mapper.Map<Appointment, AppointmentDTO>(Database.Appointments.Get(id));
        }

        public void DeleteAppointment(int id)
        {
            Database.Appointments.Delete(id);
        }

        public void Update(AppointmentDTO appointmentDTO)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, Appointment>().ForMember(a => a.Doctor, opt => opt.Ignore())).CreateMapper();
            var appointment = mapper.Map<AppointmentDTO, Appointment>(appointmentDTO);
            Database.Appointments.Update(appointment);

        }
    }
}
