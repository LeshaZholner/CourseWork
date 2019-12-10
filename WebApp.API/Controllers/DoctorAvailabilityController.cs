using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApp.API.Models.Doctor;
using WebApp.API.Models.DoctorAvailability;
using WebApp.API.Models.Specialization;
using WebApp.BLL.DTO;
using WebApp.BLL.Services.DoctorAvailabilityService;
using WebApp.BLL.Services.DoctorService;

namespace WebApp.API.Controllers
{
    [Authorize]
    public class DoctorAvailabilityController : ApiController
    {
        
        IDoctorAvailabilityService doctorAvailabilityService;
        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService, IDoctorService doctorService)
        {
            this.doctorAvailabilityService = doctorAvailabilityService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public IEnumerable<DoctorAvailabilityViewModel> Get(int doctorId)
        {
            var doctorAvailabilityDTO = doctorAvailabilityService.GetDoctorAvailabilitys(doctorId);
            var mapper = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<DoctorAvailabilityDTO, DoctorAvailabilityViewModel>();
                cfg.CreateMap<DoctorDTO, DoctorViewModel>();
                cfg.CreateMap<SpecializationDTO, SpecializationViewModel>();
            }).CreateMapper();

            var doctorAvailability = mapper.Map<IEnumerable<DoctorAvailabilityDTO>, IEnumerable<DoctorAvailabilityViewModel>>(doctorAvailabilityDTO);

            return doctorAvailability;
        }
    }
}