using MediatR;

namespace Application.Categories.Commands.Delete;
public record DeleteCategoryCommand(Guid id) : IRequest;

public record DeleteCategoryRequest(Guid id);
