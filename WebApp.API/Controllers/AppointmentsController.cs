using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models.Appointment;
using WebApp.API.Models.Doctor;
using WebApp.API.Models.Specialization;
using WebApp.BLL.DTO;
using WebApp.BLL.Services.AppointmentService;
using WebApp.BLL.Services.DoctorService;

namespace WebApp.API.Controllers
{
    [Authorize]
    public class AppointmentsController : ApiController
    {
        IAppointmentService appointmentService;
        IDoctorService doctorService;
        public AppointmentsController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            this.appointmentService = appointmentService;
            this.doctorService = doctorService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] AppointmentCreateModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentCreateModel, AppointmentDTO>()).CreateMapper();
            var appointmentDTO = mapper.Map<AppointmentCreateModel, AppointmentDTO>(value);
            appointmentDTO.UserId = UserManager.FindById(User.Identity.GetUserId()).Id;
            var id = appointmentService.MakeAppointment(appointmentDTO);
            
            return CreatedAtRoute("DefaultApi", new { id }, value);
        }

        public IHttpActionResult Get(int id)
        {
            var appointmentDTO = appointmentService.GetAppointment(id);
            
            if(appointmentDTO == null)
            {
                return NotFound();
            }

            var mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AppointmentDTO, AppointmentViewModel>();
                cfg.CreateMap<DoctorDTO, DoctorViewModel>();
            }).CreateMapper();

            var appointment = mapper.Map<AppointmentDTO, AppointmentViewModel>(appointmentDTO);
            var doctorDTO = doctorService.GetDoctor(appointmentDTO.DoctorId);
            appointment.Doctor = mapper.Map<DoctorDTO, DoctorViewModel>(doctorDTO);

            return Ok(appointment);
        }

        [Route("api/appointments/edit")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] AppointmentCreateModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var appointment = appointmentService.GetAppointment(id);
            if (appointment == null)
            {
                return NotFound();
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentCreateModel, AppointmentDTO>().ForMember(a => a.Doctor, opt => opt.Ignore())).CreateMapper();
            var appointmentDTO = mapper.Map<AppointmentCreateModel, AppointmentDTO>(value);
            appointmentDTO.Id = id;
            appointmentDTO.UserId = UserManager.FindById(User.Identity.GetUserId()).Id;
            appointmentService.Update(appointmentDTO);
            return Ok();
        }

        [Route("api/appointments/remove")]
        [HttpPost]
        public void Remove([FromBody] int id)
        {
            appointmentService.DeleteAppointment(id);
        }

        public IEnumerable<AppointmentViewModel> GetAppointments()
        {
            var appointmentDTO = appointmentService.GetAppointments(UserManager.FindById(User.Identity.GetUserId()).Id);
            var mapper = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<AppointmentDTO, AppointmentViewModel>();
                cfg.CreateMap<DoctorDTO, DoctorViewModel>();
                cfg.CreateMap<SpecializationDTO, SpecializationViewModel>();
            }).CreateMapper();
            
            var appointments = mapper.Map<IEnumerable<AppointmentDTO>, IEnumerable<AppointmentViewModel>>(appointmentDTO);

            return appointments;
        }
    }
}
