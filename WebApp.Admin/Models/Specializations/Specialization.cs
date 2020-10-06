using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.Admin.Models.Doctors;

namespace WebApp.Admin.Models.Specializations
{
    public class Specialization
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
