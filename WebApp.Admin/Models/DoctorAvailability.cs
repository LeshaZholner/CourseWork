using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Admin.CustomValidation;
using WebApp.Admin.Models.Doctors;

namespace WebApp.Admin.Models
{
    public class DoctorAvailability
    {
        public int Id { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [ScheduleDate]
        public DateTime DateAvailability { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan TimeFrom { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [CompareTime]
        public TimeSpan TimeTo { get; set; }
    }
}