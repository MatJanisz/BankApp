using BankApp.Models;
using BankApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace BankApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: User
        public ActionResult New()
        {
            var types = _context.TypeAccount.ToList();
            var viewModel = new UserAccountViewModel()
            {
                TypeAccounts = types,
                UserAccount = new UserAccount()

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(UserAccount userAccount) //tutaj model binding
        {
            if (!ModelState.IsValid) //Modelstate, czy warunki narzuce przez data annotations dla poszczegolnych pol są spełnione
            {
                //    var modelStateErrors = ModelState //do sprawdzenia bledu
                //.Where(x => x.Value.Errors.Count > 0)
                //.Select(x => new { x.Key, x.Value.Errors })
                //.ToArray();
                var viewModel = new UserAccountViewModel()
                {
                    UserAccount = userAccount,
                    TypeAccounts = _context.TypeAccount.ToList()
                };
                return View("New", viewModel);
            }


            if (userAccount.Id == 0)
            {
                string accountNumberCandidate;
                bool checker;
                do
                {
                    checker = false;
                    var usedAccountNumbers = _context.UserAccount
                        .Select(n => n.AccoutNumber).ToList();
                    accountNumberCandidate = GenerateAccountNumber();
                    foreach (var item in usedAccountNumbers)
                    {
                        if (item.Equals(accountNumberCandidate))
                            checker = true;
                    }
                } while (checker);
                

                userAccount.AccoutNumber =accountNumberCandidate;
                userAccount.RegisterId = User.Identity.GetUserId();
                _context.UserAccount.Add(userAccount);
            }
                
            else
            {
                var customerInDb = _context.UserAccount.Single(c => c.Id == userAccount.Id);
                customerInDb.Name = userAccount.Name;
                customerInDb.Surname = userAccount.Surname;
                customerInDb.Money = userAccount.Money;
                customerInDb.DateOfBirth = userAccount.DateOfBirth;
                customerInDb.TypeAccountId = userAccount.TypeAccountId;
            }

            _context.SaveChanges();

            //return View();
            return RedirectToAction("StartPage","User");
        } 
        [Authorize(Roles ="AdminAction")]
        public ActionResult ShowUsers()
        {
            var users = _context.UserAccount.Include(c => c.TypeAccount).ToList();
            return View(users);
        }

        [Authorize(Roles = "AdminAction")]
        public ActionResult Edit(int id)
        {
            var user = _context.UserAccount.SingleOrDefault(c => c.Id == id);
            var viewModel = new UserAccountViewModel
            {
                UserAccount = user,
                TypeAccounts = _context.TypeAccount.ToList()
            };
            return View("New", viewModel);
     
        }

        [Authorize(Roles = "AdminAction")]
        public ActionResult Delete(int id)
        {
            //tabele AspNetUsers i UserAccounts polaoczone polem registerId

            var user = _context.UserAccount.SingleOrDefault(c => c.Id == id); //znalezienie 
            //konkretnego usera z tabeli UserAccounts

            var userAspNetUser = _context.Users.Find(user.RegisterId);
            //znalezienie usera z tabeli AspNetUsers

            _context.Users.Remove(userAspNetUser);//usuniecie z AspNetUsers

            _context.UserAccount.Remove(user);//usuniecie z UserAccounts

            _context.SaveChanges();//zapisanie zmian

            return RedirectToAction("ShowUsers", "User");
        }

        public ActionResult ShowUserData()
        {
            var registerIdUser = User.Identity.GetUserId();

            var user = _context.UserAccount.SingleOrDefault(c => c.RegisterId.Equals(registerIdUser));
            var viewModel = new UserAccountViewModel
            {
                UserAccount = user,
                TypeAccounts = _context.TypeAccount.ToList()
            };
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult StartPage()
        {
            return View();
        }

        public static string GenerateAccountNumber()
        {
            StringBuilder result = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
                result.Append(rand.Next(0,9));

            return result.ToString();
        }
    }
}