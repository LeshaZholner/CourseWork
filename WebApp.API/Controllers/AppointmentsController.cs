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
        public void Post([FromBody] AppointmentViewModel value)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentViewModel, AppointmentDTO>()).CreateMapper();
            var appointmentDTO = mapper.Map<AppointmentViewModel, AppointmentDTO>(value);
            appointmentService.MakeAppointment(appointmentDTO);
        }

        public IEnumerable<AppointmentViewModel> Get()
        {
            var appointmentDTO = appointmentService.GetAppointments();
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<AppointmentDTO, AppointmentViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<AppointmentDTO>, IEnumerable<AppointmentViewModel>>(appointmentDTO);
        }
    }
}
