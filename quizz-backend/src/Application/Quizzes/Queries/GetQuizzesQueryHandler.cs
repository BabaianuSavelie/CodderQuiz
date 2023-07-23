using Application.Data;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Quizzes.Queries;

public class GetQuizzesQueryHandler : IRequestHandler<GetQuizzesQuery,IEnumerable<Quizz>>
{ 
    private readonly IApplicationDbContext _context;

    public GetQuizzesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Quizz>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Quizzes
            .Include(q=>q.Category)
            .Include(q=>q.Questions)
            .ThenInclude(q=>q.Options)
            .ToListAsync(cancellationToken);
    }
}
