using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizAPI.Contracts;
using quizAPI.Data;
using quizAPI.Models;
using quizAPI.Services;

namespace quizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        readonly PlayerManager _manager;
        public PlayersController(IUnitOfWork unitOfWork, PlayerManager manager)
        {
            _manager = manager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreatePlayer([FromBody] RegisterViewModel model)
        {
            await _manager.CreatePlayer(model);

            return Ok(model);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] UpdatePlayerViewModel model)
        {
            string result = await _manager.UpdatePlayer(id, model);

            if (result != null)
                return NotFound(result);

            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            string result = await _manager.DeletePlayer(id);

            if (result != null)
                return NotFound(result);

            return Ok(result);
        }
    }
}
