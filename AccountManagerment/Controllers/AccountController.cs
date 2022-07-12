using Microsoft.AspNetCore.Mvc;
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

        public AccountController(AssignmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult RegisterFail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterSuccess(Account account)
        {
            return View(account);
        }

        [HttpGet]
        public ActionResult Register2(List<Error> errors = null)
        {
            ViewBag.errors = errors;
            return View();
        }

        [HttpPost]
        public ActionResult Register2(Account account)
        {
            if (ModelState.IsValid)
            {
                AccountValidate validate = new AccountValidate();
                validate.IsValidateAccount(account);
                if (validate.valid)
                {
                    _accountRepostory = new AccountRepository(this._context, new AccountDatabaseAction());
                    _accountService = new AccountService(_accountRepostory);
                    var newAccount = _accountService.Register(account);
                    if (newAccount == null)
                    {
                        return RedirectToAction("RegisterFail");
                    }
                    else
                    {
                        return RedirectToAction("RegisterSuccess", newAccount);
                    }
                }
                else return this.Register2(validate.errors);
            }
            else return View(account);
        }

        //[HttpGet]
        //public ActionResult Register(List<Error> errors = null)
        //{
        //    ViewBag.errors = errors;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AccountValidate validate = new AccountValidate();
        //        validate.IsValidateAccount(account);
        //        if (validate.valid)
        //        {
        //            var newAcc = _accountService.Register(account);
        //            if (newAcc == null) return RedirectToAction("RegisterFail");
        //            else return RedirectToAction("RegisterSuccess", newAcc);
        //        }
        //        else return this.Register(validate.errors);
        //    }
        //    else return View(account);
        //}
    }
}
