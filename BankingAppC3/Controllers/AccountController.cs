using Microsoft.AspNetCore.Mvc;
//using BankingAppC3.Services; // Correct namespace for services
//using BankingAppC3.Models;

namespace BankingAppC3.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IAccountService _accountService;

        //public AccountController(IAccountService accountService)
        //{
        //    _accountService = accountService;
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
