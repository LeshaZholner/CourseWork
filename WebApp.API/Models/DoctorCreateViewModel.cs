using System.ComponentModel.DataAnnotations;

namespace WebApp.API.Models
{
    public class DoctorCreateViewModel
    {
        [Required]
        public int SpecializationId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}