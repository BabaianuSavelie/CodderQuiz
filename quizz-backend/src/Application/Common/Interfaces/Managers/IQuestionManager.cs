using Domain.Models;

namespace Application.Common.Interfaces.Managers;
public interface IQuestionManager
{
    Task<Question> CreateAsync(Question question, CancellationToken cancellationToken);
}
