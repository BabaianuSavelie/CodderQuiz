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

        public async Task<IList<TType>> FindAll<TType>(
            Expression<Func<T, bool>> where = null,
            Expression<Func<T, TType>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            List<string> includes = null,
            int? skip = null,
            int? take = null)
        {
            IQueryable<T> query = _db;

            if (where != null)
                query = query.Where(where);

            if (includes != null)
                foreach (var table in includes)
                    query = query.Include(table);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (skip != null)
                query = query.Skip((int)skip);

            if (take != null)
                query = query.Take((int)take);

            return
                (select != null)
                ? await query.Select(select).ToListAsync()
                : (IList<TType>)await query.ToListAsync();
        }

        public async Task Create(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Remove(entity);
        }


        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
