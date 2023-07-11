using Application.Common.Interfaces.Managers;
using Application.Common.Interfaces.Repository;
using Domain.Models;

namespace Application.Managers;
public class OptionManager : IOptionManager
{
    private readonly IOptionRepository _optionRepository;

    public OptionManager(IOptionRepository optionRepository)
    {
        _optionRepository = optionRepository;
    }

    public async Task<Option> CreateAsync(Option option, CancellationToken cancellationToken)
    {
        await _optionRepository.CreateAsync(option, cancellationToken);

        return option;
    }

    public Question Update(Option option)
    {
        throw new NotImplementedException();
    }
}
