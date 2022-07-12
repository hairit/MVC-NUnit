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
        private readonly AccountService _accountService;
        private readonly AccountRepository _accountRepository;
        public AccountAPIController(AssignmentContext context)
        {
            _context = context;
            _accountRepository = new AccountRepository(context, new AccountDatabaseAction());
            _accountService = new AccountService(_accountRepository);
        }
        [HttpGet]
        public ResponseAccount GetAccounts()
        {
            return _accountService.getAccounts();
        }
    }
}
