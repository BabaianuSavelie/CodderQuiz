using Application.Data;
using Application.Questions.Queries.GetQuestions;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Quizzes.Queries;

public class GetQuizzesQueryHandler : IRequestHandler<GetQuizzesQuery,IEnumerable<GetQuizzesResponse>>
{ 
    private readonly IApplicationDbContext _context;

    public GetQuizzesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetQuizzesResponse>> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Quizzes
            .Include(q=>q.Category)
            .Include(q=>q.Questions)
            .ThenInclude(q=>q.Options)
            .ToListAsync(cancellationToken);


        return result.Select(q =>
               new GetQuizzesResponse(
                   q.Id,
               q.Title,
               q.Description,
               q.Category, 
               q.Questions.Select(x => 
               new GetQuestionResponse(
                   x.Id,
                   x.Text,
                   x.Options.Select(o => new OptionResponse(o.Id,o.Label,o.IsCorrect)).ToList())).ToList(),
                 q.CreatedAt,
                 q.UpdatedAt
                   )).OrderByDescending(q=>q.CreatedAt);
    }
}
