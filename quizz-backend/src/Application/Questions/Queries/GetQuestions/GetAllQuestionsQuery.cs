using Domain.Models;
using MediatR;

namespace Application.Questions.Queries.GetQuestions;
public record GetAllQuestionsQuery : IRequest<IEnumerable<Question>>;

public record GetQuestionResponse(Guid Id,
    string Text,
    List<OptionResponse> Options);

public record OptionResponse(Guid Id,
    string Label,
    bool IsCorrect);