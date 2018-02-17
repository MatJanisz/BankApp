using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.ViewModel
{
    public class UserAccountViewModel
    {
        public List<TypeAccount> TypeAccounts { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}