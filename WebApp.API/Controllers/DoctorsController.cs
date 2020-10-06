using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models.Doctor;
using WebApp.API.Models.Specialization;
using WebApp.BLL.DTO;
using WebApp.BLL.Services.DoctorService;
using WebApp.BLL.Services.SpecializationService;

namespace WebApp.API.Controllers
{
    [Authorize]
    public class DoctorsController : ApiController
    {
        IDoctorService doctorService;
        ISpecializationService specializationService;

        public DoctorsController(IDoctorService doctorService, ISpecializationService specializationService)
        {
            this.doctorService = doctorService;
            this.specializationService = specializationService;
        }

        public IHttpActionResult Get(int id)
        {
            var doctorDTO = doctorService.GetDoctor(id);
            if (doctorDTO == null)
            {
                return NotFound();
            }

            var mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDTO, DoctorViewModel>();
                cfg.CreateMap<SpecializationDTO, SpecializationViewModel>();
            }).CreateMapper();

            var doctor = mapper.Map<DoctorDTO, DoctorViewModel>(doctorDTO);
            doctor.Specialization = mapper.Map<SpecializationDTO, SpecializationViewModel>(specializationService.GetSpecialization(doctor.SpecializationId));

            return Ok(doctor);
        }

        [Route("api/doctors/getdoctorsbyspecializationId")]
        [HttpGet]
        public IEnumerable<DoctorViewModel> GetDoctors(int? specializationId = 0)
        {
            var doctorsDTO = specializationId != 0 ? doctorService.GetDoctors(d => d.SpecializationId == specializationId) : doctorService.GetDoctors();
            var mapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorDTO, DoctorViewModel>();
                cfg.CreateMap<SpecializationDTO, SpecializationViewModel>();
            }).CreateMapper();

            var doctors = mapper.Map<IEnumerable<DoctorDTO>, IEnumerable<DoctorViewModel>>(doctorsDTO);
            
            return doctors;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DoctorCreateModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<DoctorCreateModel, DoctorDTO>()).CreateMapper();
            var doctorDTO = mapper.Map<DoctorCreateModel, DoctorDTO>(value);
            var id = doctorService.AddDoctor(doctorDTO);

            return CreatedAtRoute("DefaultApi", new { id }, value);
        }
    }
}
