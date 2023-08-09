using Application.Questions.Queries.GetQuestions;
using Domain.Models;
using MediatR;

namespace Application.Quizzes.Queries;
public record GetQuizzesQuery : IRequest<IEnumerable<GetQuizzesResponse>>;

public record GetQuizzesResponse(
    Guid Id,
    string Title,
    string Description,
    Category Category,
    List<GetQuestionResponse> Questions,
    DateTime CreatedAt,
    DateTime UpdatedAt);