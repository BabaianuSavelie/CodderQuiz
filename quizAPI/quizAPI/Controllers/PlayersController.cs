using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizAPI.Contracts;
using quizAPI.Data;
using quizAPI.Models;

namespace quizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public PlayersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreatePlayer([FromBody] RegisterViewModel model)
        {
            Player player = new Player
            {
                Email = model.Email,
                Username = model.Username,
                Score = 0,
                ElapsedTime = 0
            };

            var existentPlayer = (await _unitOfWork.Players
                .Find<Player>(p => p.Email == player.Email
                && p.Username == model.Username))
                .FirstOrDefault();

            if (existentPlayer is null)
            {
                await _unitOfWork.Players.Create(player);
                await _unitOfWork.Save();
            }
            else
                player = existentPlayer;

            return Ok(model);
        }
    }
}
