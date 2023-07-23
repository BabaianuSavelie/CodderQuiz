using Domain.Models;

namespace Application.Common.Interfaces.Repository;
public interface IQuestionRepository
{
    Task<Question?> GetByIdAsync(Guid id);
    Task<Question> CreateAsync(Question question, CancellationToken cancellationToken);
    void Delete(Question question);
    void Update(Question question);
}
