using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models;
using WebApp.BLL.DTO;
using WebApp.BLL.Services.AppointmentService;

namespace WebApp.API.Controllers
{
    [Authorize]
    public class AppointmentsController : ApiController
    {
        IAppointmentService appointmentService;
        
        public AppointmentsController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] AppointmentCreateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentCreateViewModel, AppointmentDTO>()).CreateMapper();
            var appointmentDTO = mapper.Map<AppointmentCreateViewModel, AppointmentDTO>(value);
            var id = appointmentService.MakeAppointment(appointmentDTO);

            return CreatedAtRoute("DefaultApi", new { id }, value);
        }

        public IEnumerable<AppointmentViewModel> Get()
        {
            var appointmentDTO = appointmentService.GetAppointments();
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<AppointmentDTO>, IEnumerable<AppointmentViewModel>>(appointmentDTO);
        }
    }
}
