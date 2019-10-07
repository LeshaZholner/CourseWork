using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.API.Models;
using WebApp.BLL.DTO;
using WebApp.BLL.Services.SpecializationService;

namespace WebApp.API.Controllers
{
    public class SpecializationsController : ApiController
    {
        ISpecializationService specializationService;

        public SpecializationsController(ISpecializationService serv)
        {
            specializationService = serv;
        }

        public IEnumerable<SpecializationViewModel> Get()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SpecializationDTO, SpecializationViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<SpecializationDTO>, List<SpecializationViewModel>>(specializationService.GetSpecializations());
        }

        public void Post([FromBody]SpecializationViewModel value)
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SpecializationViewModel, SpecializationDTO>()).CreateMapper();
            specializationService.AddSpecialization(mapper.Map<SpecializationViewModel, SpecializationDTO>(value));
        }
    }
}
