
using Application.Common.Interfaces.Managers;
using Application.Data;
using Domain.Models;
using MediatR;

namespace Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Question>
{
    private readonly IQuestionManager _questionManager;
    private readonly IOptionManager _optionManager;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuestionCommandHandler(IQuestionManager questionManager, IUnitOfWork unitOfWork)
    {
        _questionManager = questionManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Question> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            Text = request.Text,
            Options = request.Options.Select(o => new Option
            {
                Id = Guid.NewGuid(),
                Label = o.Label,
                IsCorrect = o.IsCorrect
            }).ToList(),
        };


        var result = await _questionManager.CreateAsync(question, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return question;
    }
}


