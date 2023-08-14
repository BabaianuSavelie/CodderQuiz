using Application.Categories.Commands.Create;
using MediatR;

namespace Application.Categories.Commands.Update;
public record UpdateCategoryCommand(Guid Id,CategoryRequest Category) : IRequest;
