using Domain.Models;

namespace Application.Common.Interfaces.Repositories;
public interface IQuizzRepository
{
    Task<Quizz> CreateAsync(Quizz quizz, CancellationToken cancellationToken);
}
