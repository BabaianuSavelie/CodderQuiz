using MediatR;

namespace Application.Categories.Queries.GetAllCategories;
public record GetCategoriesQuery() : IRequest<IEnumerable<CategoryResponse>>;

public record CategoryResponse(Guid Id, string Name);
