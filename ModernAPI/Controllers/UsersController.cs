using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modern.BisnessAccessLayer.IRepository;
using Modern.Object.Models;

namespace ModernAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private ILoginBusinessLogic _loginBusinessLogic;

        public UsersController(ILoginBusinessLogic loginBusinessLogic)
        {
            _loginBusinessLogic = loginBusinessLogic;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _loginBusinessLogic.LoginDetailsFromBusiness(model.Username, model.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet("validatetoken")]
        public IActionResult ValidateToken(string token)
        {
            var response = _loginBusinessLogic.ValidateJwtToken(token);
            return Ok(new { isValid = response });
        }

        //[Authorize]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}
    }
}
