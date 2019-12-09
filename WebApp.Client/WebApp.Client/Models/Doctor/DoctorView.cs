using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models.Doctor
{
    public class DoctorView
    {
        public int Id { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string DoctorName
        {
            get
            {
                return $"{FirstName} {SecondName}";
            }
        }
    }
}
