using Domain.Models;

namespace Application.Common.Interfaces.Managers;
public interface IOptionManager
{
    Task<Option> CreateAsync(Option option, CancellationToken cancellationToken);
    Question Update(Option option);
}
