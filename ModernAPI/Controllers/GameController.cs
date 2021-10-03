using Microsoft.AspNetCore.Mvc;
using Modern.BisnessAccessLayer.IRepository;

namespace ModernAPI.Controllers
{
    [Route("api/v1/Games")]
    [ApiController]
    public class GameController : Controller
    {
        private IGameBusinessLogic _gamesRepository;
        public GameController(IGameBusinessLogic gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        //[Authorize]
        [HttpGet()]
        public IActionResult GetGames()
        {
            var result = _gamesRepository.GetGamesList();
            return Ok(result);
        }
    }
}
