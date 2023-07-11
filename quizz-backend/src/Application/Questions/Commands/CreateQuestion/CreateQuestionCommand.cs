using Application.Common.Requests;
using Domain.Models;
using MediatR;

namespace Application.Questions.Commands.CreateQuestion;
public record CreateQuestionCommand(string Text, List<OptionRequest> Options) : IRequest<Question>;


