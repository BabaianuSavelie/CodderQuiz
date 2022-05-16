using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using quizAPI.Contracts;
using quizAPI.Data;
using System.Linq.Expressions;

namespace quizAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly ApplicationDbContext _context;
        readonly DbSet<T> _db;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task<IList<TType>> Find<TType>(
            Expression<Func<T, bool>> where = null,
            Expression<Func<T, TType>> select = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (include != null)
            {
                query = include(query);
            }

            return
                (select != null)
                ? await query.Select(select).ToListAsync()
                : (IList<TType>)await query.ToListAsync();
        }
        public async Task Create(T entity)
        {
            await _db.AddAsync(entity);
        }


        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
