using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AccountManagerment.Models;
using AccountManagerment.Models.ModelValidate;
using AccountManagerment.Repositories;
using AccountManagerment.Services;

namespace AccountManagerment.Controllers
{
    public class AccountController : Controller
    {
        private readonly AssignmentContext _context;
        private AccountRepository _accountRepostory;
        private AccountService _accountService;
        private AccountDatabaseAction action;
        public AccountController(AssignmentContext context)
        {
            _context = context;
            _accountRepostory = new AccountRepository(context,new AccountDatabaseAction());
            _accountService = new AccountService(_accountRepostory);
        }
        [HttpGet]
        public ActionResult RegisterFail()
        {
            return View();
        }
        public ActionResult RegisterSuccess(Account account)
        {
            return View(account);
        }
        [HttpGet]
        public ActionResult Register(List<string> errors = null)
        {
            ViewBag.errors = errors;
            return View();
        }
        [HttpGet]
        public ActionResult Register2(List<string> errors = null)
        {
            ViewBag.errors = errors;
            return View();
        }
        [HttpPost]
        public ActionResult Register2(Account acc)
        {
            if (ModelState.IsValid)
            {
                AccountValidate validate = new AccountValidate();
                validate.isValidateAccount(acc.Email, acc.Fullname);
                if (validate.valid)
                {
                    var newAcc = _accountService.Register(acc.Email, acc.Fullname);
                    if (newAcc == null) return RedirectToAction("RegisterFail");
                    else return RedirectToAction("RegisterSuccess", newAcc);
                }
                else return this.Register2(validate.errors);
            }
            else return View(acc);
        }
        [HttpPost]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                AccountValidate validate = new AccountValidate();
                validate.isValidateAccount(acc.Email, acc.Fullname);
                if (validate.valid)
                {
                    var newAcc = _accountService.Register(acc.Email,acc.Fullname);
                    if (newAcc == null) return RedirectToAction("RegisterFail");
                    else return RedirectToAction("RegisterSuccess", newAcc);
                }
                else return this.Register(validate.errors);
            }
            else return View(acc);
        }
    }
}
