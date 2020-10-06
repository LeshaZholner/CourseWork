using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.API.Models.Specialization;

namespace WebApp.API.Models.Doctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public int SpecializationId { get; set; }
        public SpecializationViewModel Specialization { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
    }
}