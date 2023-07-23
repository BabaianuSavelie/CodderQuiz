using Application.Common.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Persistence.Repositories;
public class QuizzRepository : IQuizzRepository
{
    private readonly ApplicationDbContext _context;

    public QuizzRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Quizz> CreateAsync(Quizz quizz, CancellationToken cancellationToken)
    {
        await _context.Quizzes.AddAsync(quizz);

        return quizz;
    }
}
