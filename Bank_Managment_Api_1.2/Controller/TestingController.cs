using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Managment_Api_1._2.Controller
{
    [Route("test")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        [HttpGet("Error test")]
        public Task<ActionResult> ThrowError()
        {
            throw new Exception("artifical error thrown");
        }

    }
}
