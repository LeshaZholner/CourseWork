using System.ComponentModel.DataAnnotations;
using WebApp.Admin.Models.Specializations;

namespace WebApp.Admin.Models.Doctors
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public int SpecializationId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public virtual Specialization Specialization { get; set; }

    }
}
