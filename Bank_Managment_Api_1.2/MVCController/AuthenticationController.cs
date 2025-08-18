using Bank_Managment_Api_1._2.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationController.MVCController
{
    [Route("[controller]/[action]")]
    public class AuthenticationController : Controller
    {   
        // GET: AuthController
        [AllowAnonymous]
        // [HttpPost]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        // [HttpPost]
        public ActionResult LogIn()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("Authentication/RegisterSubmitted")]
        // [HttpPost]
        public IActionResult RegisterSubmitted(CreateUserDto newUser)
        {
            return View();
        }

    }
}
