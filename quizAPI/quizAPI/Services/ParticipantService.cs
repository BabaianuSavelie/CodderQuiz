using quizAPI.Contracts;
using quizAPI.Models;

namespace quizAPI.Services
{
    public class ParticipantService
    {
        readonly IUnitOfWork _unitOfWork;
        public ParticipantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreatePlayer(Player player)
        {
            await _unitOfWork.Players.Create(player);
        }

        public async Task UpdatePlayer(int id,PlayerResult result)
        {
            var player = (await _unitOfWork.Players
                .Find<Player>(p => p.Id == id))
                .FirstOrDefault();




        }
    }
}
