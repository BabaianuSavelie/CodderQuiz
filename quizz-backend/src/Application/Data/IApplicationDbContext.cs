using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;
public interface IApplicationDbContext
{
    DbSet<Question> Questions { get; }
    DbSet<Option> Options { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
