using Domain.Models;
using MediatR;

namespace Application.Categories.Commands.Create;
public record CreateCategoryCommand(string name) : IRequest<Category>;

public record CategoryRequest(string Name);