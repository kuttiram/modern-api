using Microsoft.AspNetCore.Mvc;
using Modern.BisnessAccessLayer.IRepository;

namespace ModernAPI.Controllers
{
    [Route("api/v1/Home")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHomeBusinessLogic _homeBusinessLogic;
        public HomeController(IHomeBusinessLogic homeBusinessLogic)
        {
            this._homeBusinessLogic = homeBusinessLogic;
        }

        [HttpGet("GetTitle")]
        public IActionResult GetTitle()
        {
            var responseResult = this._homeBusinessLogic.GetHomeTitle();
            if (responseResult == null)
                return NoContent();
            return Ok(responseResult);
        }

        [HttpGet("GetBanner")]
        public IActionResult GetBanner()
        {
            var responseResult = this._homeBusinessLogic.GetPageContentBanner();
            if (responseResult == null)
                return NoContent();
            return Ok(responseResult);
        }
    }
}
