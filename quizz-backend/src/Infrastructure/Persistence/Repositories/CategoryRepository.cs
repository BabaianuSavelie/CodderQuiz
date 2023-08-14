using Application.Common.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Persistence.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task<Category> CreateAsync(Category category, CancellationToken cancellationToken)
    {
        await _context.Categories.AddAsync(category);

        return category;
    }

    public void Delete(Category category)
    {
         _context.Categories.Remove(category);
    }

    public void Update(Category category) 
    { 
        _context.Categories.Update(category);
    }
}
