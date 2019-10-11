using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DAL.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public int SpecializationId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
