using Bank_Managment_Api_1._2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Managment_Api_1._2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Register_Login : ControllerBase
    {
        private BankAccountContext _dbContext;

        public Register_Login(BankAccountContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        
    }
}
