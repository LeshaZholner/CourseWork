using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models;
using WebApp.BLL.DTO;
using WebApp.BLL.Services.DoctorService;

namespace WebApp.API.Controllers
{
    [Authorize]
    public class DoctorsController : ApiController
    {
        IDoctorService appointmentService;

        public DoctorsController(IDoctorService serv)
        {
            appointmentService = serv;
        }

        public IEnumerable<DoctorViewModel> Get()
        {
            var doctorsDTO = appointmentService.GetDoctors();
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorViewModel>()).CreateMapper();
            var doctors = mapper.Map<IEnumerable<DoctorDTO>, IEnumerable<DoctorViewModel>>(doctorsDTO);
            return doctors;
        }
    }
}
