using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizAPI.Contracts;
using quizAPI.Models;

namespace quizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public QuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = (await _unitOfWork.Questions
                .FindAll<Question>())
                .OrderBy(x => Guid.NewGuid())
                .Take(5).ToList();

            if (questions != null)
                return Ok(questions);

            return BadRequest();
        }
    }
}
