using Domain.Models;
using MediatR;

namespace Application.Quizzes.Commands.Create;
public record CreateQuizzCommand(
    string Title,
    string Description,
    Guid CategoryId) : IRequest<QuizzResponse>;


public record QuizzRequest(string Title,
    string Description,
    Guid CategoryId);


public record QuizzResponse(Guid Id,
    string Title,
    string Description);