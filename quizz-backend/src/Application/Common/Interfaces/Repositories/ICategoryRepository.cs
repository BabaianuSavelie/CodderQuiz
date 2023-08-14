using Domain.Models;

namespace Application.Common.Interfaces.Repositories;
public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category> CreateAsync(Category category,CancellationToken cancellationToken);
    void Delete(Category category);
    void Update(Category category);
}
