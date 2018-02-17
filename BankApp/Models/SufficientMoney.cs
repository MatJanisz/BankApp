using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class SufficientMoney : ValidationAttribute
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var registerIdUser = HttpContext.Current.User.Identity.GetUserId();
            var transfer = (Transfer)validationContext.ObjectInstance;

             var logiInUser = _context.UserAccount
            .SingleOrDefault(c => c.RegisterId.Equals(registerIdUser));

           
            if (logiInUser.Money-transfer.TransferMoney>=0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("You dont have enough money");
            }
        }
    }
}