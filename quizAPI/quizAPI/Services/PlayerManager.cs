using quizAPI.Contracts;
using quizAPI.Models;

namespace quizAPI.Services
{
    public class PlayerManager
    {
        readonly IUnitOfWork _unitOfWork;
        public PlayerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreatePlayer(RegisterViewModel model)
        {
            Player player = new Player
            {
                Email = model.Email,
                Username = model.Username,
                Score = 0,
                ElapsedTime = 0
            };

            //Verify if the player exist in db
            var existentPlayer = (await _unitOfWork.Players
               .Find<Player>(p => p.Username == player.Username
               && p.Email == player.Email))
               .SingleOrDefault();

            if (existentPlayer is null)
            {
                await _unitOfWork.Players.Create(player);
                await _unitOfWork.Save();
            }
        }
        public async Task<string> DeletePlayer(int id)
        {
            var playerToRemove = (await _unitOfWork.Players
                .Find<Player>(p => p.Id == id))
                .FirstOrDefault();

            if (playerToRemove is null)
                return "This player does not exist!";

            _unitOfWork.Players.Delete(playerToRemove);
            await _unitOfWork.Save();

            return null;
        }
        public async Task<string> UpdatePlayer(int id, UpdatePlayerViewModel model)
        {
            var existentPlayer = (await _unitOfWork.Players
                .Find<Player>(p => p.Id == id))
                .FirstOrDefault();

            if (existentPlayer is null)
                return "Player does not exist";

            existentPlayer.Score = model.Score;
            existentPlayer.ElapsedTime = model.ElapsedTime;

            _unitOfWork.Players.Update(existentPlayer);
            await _unitOfWork.Save();

            return null;
        }
    }
}
