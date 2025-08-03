using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Dto;
using Bank_Managment_Api_1._2.Entities;
using Bank_Managment_Api_1._2.Mapping;
using Bank_Managment_Api_1._2.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Bank_Managment_Api_1._2.Controller
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private BankAccountContext _dbContext;

        public AuthController(BankAccountContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDetailsDto>> GetUser(int id)
        {
            User? user = await _dbContext.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user.ToUserDetailsDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDetailsDto>> PostRegister(CreateUserDto NewUser)
        {

            User user = NewUser.ToEntity();
            user.Role = user.Role.ToLower();
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.Id },
                user.ToUserDetailsDto()
            );
        }
        [HttpPost("login")]
        public async Task<ActionResult> PostLogin(CreateLoginDto login)
        {
            var userInDatabase = await _dbContext.users.FirstOrDefaultAsync(x => x.Name == login.UserName);
            if (userInDatabase == null)
            {
                return Unauthorized("Password or UserName is invalid");
            }

            if (!BCrypt.Net.BCrypt.Verify(login.Password, userInDatabase.HashedPassword))
            {
                return Unauthorized("Password or UserName is invalid");
            }
            var token = AuthServices.GenerateJWTToken(login.UserName);
            return Ok(new { token });
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<ActionResult> PostLogout()
        {
            var jti = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            var BlackListedToken = TokenMapping.ToEntityFromString(jti);
            
            await _dbContext.tokenblacklist.AddAsync(BlackListedToken);
            await _dbContext.SaveChangesAsync();

            return Ok("Token Black Listed");
        }

                
    }
}
