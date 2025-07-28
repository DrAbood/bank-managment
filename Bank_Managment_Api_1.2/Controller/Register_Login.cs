using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using Bank_Managment_Api_1._2.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Managment_Api_1._2.Controller
{
    [Route("Register")]
    [ApiController]
    public class Register_Login : ControllerBase
    {
        private BankAccountContext _dbContext;

        public Register_Login(BankAccountContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsDto>> GetUser(int id)
        {
            User? user = await _dbContext.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user.ToUserDetailsDto();
        }

        [HttpPost]
        public async Task<ActionResult<UserDetailsDto>> PostRegister(CreateUserDto NewUser)
        {
            User user = NewUser.ToEntity();
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.Id },
                user.ToUserDetailsDto()
            );
        }
        
        
    }
}
