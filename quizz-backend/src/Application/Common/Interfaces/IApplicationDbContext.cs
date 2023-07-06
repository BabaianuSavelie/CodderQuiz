using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Question> Questions { get; }
    DbSet<Option> Options { get; }
}
