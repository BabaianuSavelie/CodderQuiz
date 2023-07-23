using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.GetAllCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetCategoriesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.ToListAsync(cancellationToken);

        return result.Select(c => new CategoryResponse(c.Id, c.Name))
            .ToList();
    }
}
