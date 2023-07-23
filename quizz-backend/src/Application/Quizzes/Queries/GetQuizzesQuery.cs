using Domain.Models;
using MediatR;

namespace Application.Quizzes.Queries;
public record GetQuizzesQuery : IRequest<IEnumerable<Quizz>>;
