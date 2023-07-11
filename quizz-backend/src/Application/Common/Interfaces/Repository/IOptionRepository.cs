using Domain.Models;

namespace Application.Common.Interfaces.Repository;
public interface IOptionRepository
{
    Task<Option> CreateAsync(Option option, CancellationToken cancellationToken);
    Option Update(Option option);
}
