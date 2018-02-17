using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class ExistenceOfAccountNumber : ValidationAttribute
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           // var registerIdUser = HttpContext.Current.User.Identity.GetUserId();
            var transfer = (Transfer)validationContext.ObjectInstance;

           // var userInUserAccounts = _context.UserAccount
                //.SingleOrDefault(c => c.RegisterId.Equals(registerIdUser));

            var targetAccountNum = _context.UserAccount
                .SingleOrDefault(n => n.AccoutNumber.Equals(transfer.TargetAccountNumber));
            if (targetAccountNum != null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Provided Account number doesn`t exist");
            }
        }
    }
}