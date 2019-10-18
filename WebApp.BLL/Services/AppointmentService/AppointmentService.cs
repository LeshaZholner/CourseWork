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

        public void MakeAppointment(AppointmentDTO appointmentDTO)
        {
            var doctor = Database.Doctors.Get(appointmentDTO.DoctorID);
            if (doctor == null)
            {
                throw new ValidationException($"Doctor {appointmentDTO.DoctorID} not found", "");
            }
            var appointment = new Appointment
            {
                PhoneNumber = appointmentDTO.PhoneNumber,
                DoctorID = appointmentDTO.DoctorID,
                DateAppointment = appointmentDTO.DateAppointment,
                TimeFrom = appointmentDTO.TimeFrom,
                TimeTo = appointmentDTO.TimeTo,
                FirstName = appointmentDTO.FirstName,
                LastName = appointmentDTO.LastName
            };
            Database.Appointments.Create(appointment);
            Database.Save();
        }

        public IEnumerable<AppointmentDTO> GetAppointments()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Appointment, AppointmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Appointment>, List<AppointmentDTO>>(Database.Appointments.GetAll());
        }
    }
}
