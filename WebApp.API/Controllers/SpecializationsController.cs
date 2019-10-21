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

        public IHttpActionResult Post([FromBody]SpecializationCreateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<SpecializationCreateViewModel, SpecializationDTO>()).CreateMapper();
            var id = specializationService.AddSpecialization(mapper.Map<SpecializationCreateViewModel, SpecializationDTO>(value));

            return CreatedAtRoute("DefaultApi", new { id }, value);
        }
    }
}
