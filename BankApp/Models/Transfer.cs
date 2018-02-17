using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class Transfer
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string NameOfTransaction { get; set; }

        [Required]
        [ExistenceOfAccountNumber]
        public string TargetAccountNumber { get; set; }

        [Required]
        public DateTime DateTransfer { get; set; }

        [Required]
        [SufficientMoney]
        public int TransferMoney { get; set; }


    }
}