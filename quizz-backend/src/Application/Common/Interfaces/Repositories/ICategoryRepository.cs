using Domain.Models;

namespace Application.Common.Interfaces.Repositories;
public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category,CancellationToken cancellationToken);
}
