using Application.Common.Interfaces.Managers;
using Application.Data;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Questions.Queries.GetQuestions;
public class GetAllQuestionsQuesryHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<Question>?>
{
    private readonly IApplicationDbContext _context;

    public GetAllQuestionsQuesryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>?> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Questions
            .Include(q=>q.Options)
            .ToListAsync(cancellationToken);
    }
}
