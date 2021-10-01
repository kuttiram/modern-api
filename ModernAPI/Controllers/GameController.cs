using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModernAPI.Interface;

namespace ModernAPI.Controllers
{
    [Route("api/v1/Games")]
    [ApiController]
    public class GameController : Controller
    {
        private IGamesRepository _gamesRepository;
        public GameController(IGamesRepository gamesRepository)
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
