using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models;
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
    }
}
