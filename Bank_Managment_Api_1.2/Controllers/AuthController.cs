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

namespace Bank_Managment_Api_1._2.Controllers
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private BankAccountContext _dbContext;
        private readonly ILogger<AuthController> _logger;

        public AuthController(BankAccountContext dbContext, ILogger<AuthController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
            _logger.LogInformation($"Fetching The User Named {user.Name}");
            return user.ToUserDetailsDto();
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDetailsDto>> PostRegister([FromBody] CreateUserDto NewUser)
        {
            try
            {
                User user = NewUser.ToEntity();
                user.Role = user.Role.ToLower();
                _dbContext.users.Add(user);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Register user: {user.Name} with id {user.Id}");
                return CreatedAtAction(
                    nameof(GetUser),
                    new { id = user.Id },
                    user.ToUserDetailsDto()
                );
                // return Json(new
                // {
                //     success = true,
                //     user = user.ToUserDetailsDto(),
                // });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    error = ex.Message
                });
            }
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
            _logger.LogInformation($"Login {login.UserName}");

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
            _logger.LogInformation("the user loggedout");
            return Ok("Token Black Listed");
        }
        // [Authorize]
        // [HttpPost("CheckCookies")]
        // public Task<ActionResult> CheckCookies()
        // {
        //     return ;
        // }

                
    }
}
