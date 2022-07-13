using Microsoft.AspNetCore.Mvc;
using AccountManagerment.Models;
using AccountManagerment.Repositories;
using AccountManagerment.Services;

namespace AccountManagerment.Controllers
{
    public class ManagerController : Controller
    {
        private readonly AssignmentContext _context;
        private AccountRepository _accountRepostory;
        private AccountService _accountService;

        public ManagerController(AssignmentContext context)
        {
            _context = context;
            _accountRepostory = new AccountRepository(context, new AccountDatabaseAction());
            _accountService = new AccountService(_accountRepostory);
        }

        public ActionResult Accounts()
        {
            ResponseAccount response = _accountService.GetAccounts();
            ViewBag.Accounts = response.data;
            return View();
        }

        // GET: Manager/Create
        [HttpGet("Manager/FormEmail/{email?}")]
        public ActionResult FormEmail(string email)
        {
            ViewBag.Email = email;
            return View();
        }
    }
}
