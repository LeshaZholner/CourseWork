using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models;
using WebApp.BLL.DTO;
using WebApp.BLL.Services;

namespace WebApp.API.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        IAppointmentService appointmentService;

        //public ValuesController(IAppointmentService serv)
        //{
        //    appointmentService = serv;
        //}

        public ValuesController()
        {
            appointmentService = new AppointmentService("DefaultConnection");
        }

        // GET api/values
        public IEnumerable<DoctorViewModel> Get()
        {
            var doctorsDTO = appointmentService.GetDoctors();
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorViewModel>()).CreateMapper();
            var doctors = mapper.Map<IEnumerable<DoctorDTO>, IEnumerable<DoctorViewModel>>(doctorsDTO);
            return doctors;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
