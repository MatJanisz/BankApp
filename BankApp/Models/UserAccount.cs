using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        public string RegisterId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string AccoutNumber { get; set; }

        [Required]
        public int Money { get; set; }

        [Required]
        [AvailabilityOfTypeAccount]
        public DateTime DateOfBirth { get; set; }

        public TypeAccount TypeAccount { get; set; }

        [Display(Name="Type account")]
        public int TypeAccountId { get; set; }

    }
}