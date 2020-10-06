using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Admin.Models;

namespace WebApp.Admin.CustomValidation
{
    public class CompareTime : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var doctorAvailability = validationContext.ObjectInstance as DoctorAvailability;
            TimeSpan dateTime = TimeSpan.Parse(value.ToString());
            if (dateTime > doctorAvailability.TimeFrom)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("TimeTo should be more than TimeFrom");
        }
    }
}