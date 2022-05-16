using quizAPI.Contracts;
using quizAPI.Data;
using quizAPI.Models;

namespace quizAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        private IGenericRepository<Player> _players;
        private IGenericRepository<Question> _questions;
        public IGenericRepository<Player> Players
            => _players??= new GenericRepository<Player>(_context);
        public IGenericRepository<Question> Questions
            => _questions??= new GenericRepository<Question>(_context);
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool dispose)
        {
            if(dispose)
                _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
