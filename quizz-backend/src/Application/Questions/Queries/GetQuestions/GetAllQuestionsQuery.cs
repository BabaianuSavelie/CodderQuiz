using Domain.Models;
using MediatR;

namespace Application.Questions.Queries.GetQuestions;
public record GetAllQuestionsQuery : IRequest<IEnumerable<Question>>;

