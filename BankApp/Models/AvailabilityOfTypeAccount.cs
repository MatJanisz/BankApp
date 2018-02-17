using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class AvailabilityOfTypeAccount : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (UserAccount)validationContext.ObjectInstance;
            if (user.TypeAccountId == 1)
                return ValidationResult.Success;

            var age = DateTime.Today.Year - user.DateOfBirth.Year;

            if((user.TypeAccountId == 2 && age<=25) || (user.TypeAccountId==3 && age<18))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Age is not correct");
            }
        }
    }
}