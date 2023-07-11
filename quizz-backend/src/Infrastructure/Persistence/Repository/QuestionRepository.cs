using Application.Common.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository;
public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDbContext _context;

    public QuestionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Question> CreateAsync(Question question, CancellationToken cancellationToken)
    {
        await _context.Questions.AddAsync(question, cancellationToken);

        return question;
    }

    public void Delete(Question question)
    {
        _context.Questions.Remove(question);
    }

    public async Task<Question?> GetByIdAsync(Guid id)
    {
        var question = await _context.Questions
            .Include(q => q.Options)
            .Where(q => q.Id == id)
            .FirstOrDefaultAsync();

        return question;
    }

    public void Update(Question question)
    {
        _context.Questions.Update(question);
    }
}
