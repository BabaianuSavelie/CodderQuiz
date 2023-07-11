using Application.Common.Interfaces.Managers;
using Application.Common.Interfaces.Repository;
using Domain.Models;

namespace Application.Managers;
public class QuestionManager : IQuestionManager
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionManager(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Question> CreateAsync(Question question, CancellationToken cancellationToken)
    {
        await _questionRepository.CreateAsync(question, cancellationToken);

        return question;
    }
}
