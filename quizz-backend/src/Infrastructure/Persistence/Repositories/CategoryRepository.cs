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

    public async Task<Category> CreateAsync(Category category, CancellationToken cancellationToken)
    {
        await _context.Categories.AddAsync(category);

        return category;
    }
}
