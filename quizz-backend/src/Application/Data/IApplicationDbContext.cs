using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;
public interface IApplicationDbContext
{
    DbSet<Question> Questions { get; }
    DbSet<Option> Options { get; }
    DbSet<Quizz> Quizzes { get; }
    DbSet<Category> Categories { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
