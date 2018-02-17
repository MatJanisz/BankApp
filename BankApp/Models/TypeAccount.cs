using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankApp.Models
{
    public class TypeAccount
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Fee { get; set; }
    }
}