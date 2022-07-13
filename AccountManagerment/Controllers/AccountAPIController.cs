using Microsoft.AspNetCore.Mvc;
using AccountManagerment.Models;
using AccountManagerment.Services;
using AccountManagerment.Repositories;

namespace AccountManagerment.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private readonly AssignmentContext _context;
        private  AccountService _accountService;
        private  AccountRepository _accountRepository;

        public AccountAPIController(AssignmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ResponseAccount GetAccounts()
        {
            _accountRepository = new AccountRepository(this._context);
            _accountService = new AccountService(_accountRepository);
            return _accountService.GetAccounts();
        }
    }
}
