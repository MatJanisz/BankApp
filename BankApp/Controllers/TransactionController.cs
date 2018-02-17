using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace BankApp.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _context;

        public TransactionController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Transaction
        public ActionResult StartTransfer()
        {
            Transfer Transfer = new Transfer();

            return View(Transfer);
        }

        [HttpPost]
        public ActionResult MakeTransfer(Transfer Transfer)
        {
            if (!ModelState.IsValid) //Modelstate, czy warunki narzuce przez data annotations dla poszczegolnych pol są spełnione
            {   
                return View("StartTransfer", Transfer);
            }

            var registerIdUser = User.Identity.GetUserId();
            var logiInUser = _context.UserAccount
                .SingleOrDefault(c => c.RegisterId.Equals(registerIdUser));

            var goalUser = _context.UserAccount
                .SingleOrDefault(c => c.AccoutNumber.Equals(Transfer.TargetAccountNumber));

            logiInUser.Money -= Transfer.TransferMoney;
            goalUser.Money += Transfer.TransferMoney;

            _context.SaveChanges();

            return RedirectToAction("ShowUserData","User");
        }
    }
}