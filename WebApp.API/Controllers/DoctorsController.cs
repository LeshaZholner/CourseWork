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
        IDoctorService doctorService;

        public DoctorsController(IDoctorService serv)
        {
            doctorService = serv;
        }

        public IHttpActionResult Get(int id)
        {
            var doctor = doctorService.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [Route("api/doctors/getdoctorsbyspecializationId")]
        [HttpGet]
        public IEnumerable<DoctorViewModel> GetDoctors(int? specializationId = 0)
        {
            var doctorsDTO = specializationId != 0 ? doctorService.GetDoctors(d => d.SpecializationId == specializationId) : doctorService.GetDoctors();
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorViewModel>()).CreateMapper();
            var doctors = mapper.Map<IEnumerable<DoctorDTO>, IEnumerable<DoctorViewModel>>(doctorsDTO);
            return doctors;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DoctorCreateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DoctorCreateViewModel, DoctorDTO>()).CreateMapper();
            var doctorDTO = mapper.Map<DoctorCreateViewModel, DoctorDTO>(value);
            var id = doctorService.AddDoctor(doctorDTO);

            return CreatedAtRoute("DefaultApi", new { id }, value);
        }
    }
}
