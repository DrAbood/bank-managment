using Bank_Managment_Api_1._2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Managment_Api_1._2.MVCController
{
    [Route("[controller]/[action]/{id?}")]
    public class AccountController : Controller
    {
        private BankAccountContext _dbContext;
        public AccountController(BankAccountContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: MainController
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        // [AllowAnonymous]
        // public IActionResult Ping() => Content("pong");


    }
}
