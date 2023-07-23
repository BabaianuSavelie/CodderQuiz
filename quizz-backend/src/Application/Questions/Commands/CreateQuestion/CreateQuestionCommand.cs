using Domain.Models;
using MediatR;

namespace Application.Questions.Commands.CreateQuestion;
public record CreateQuestionCommand(string Text,
    List<OptionRequest> Options,
    Guid QuizzId) : IRequest<Question>;

public record QuestionRequest(string Text,
    List<OptionRequest> Options,
    Guid QuizzId);

public record OptionRequest(string Label, bool IsCorrect);


