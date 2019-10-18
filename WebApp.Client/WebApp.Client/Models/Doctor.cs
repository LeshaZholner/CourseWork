using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int SpecializationId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
