using quizAPI.Models;

namespace quizAPI.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Player> Players { get; }
        IGenericRepository<Question> Questions { get; }
        Task Save();
    }
}
