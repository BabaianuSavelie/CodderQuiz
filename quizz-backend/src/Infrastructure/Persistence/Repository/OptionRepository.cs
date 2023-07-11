using Application.Common.Interfaces.Repository;
using Domain.Models;

namespace Infrastructure.Persistence.Repository;
public class OptionRepository : IOptionRepository
{
    private readonly ApplicationDbContext _context;

    public OptionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Option> CreateAsync(Option option, CancellationToken cancellationToken)
    {
        await _context.Set<Option>().AddAsync(option,cancellationToken);

        return option;
    }

    public Option Update(Option option)
    {
        throw new NotImplementedException();
    }

    public Option UpdateAsync(Option option)
    {
        _context.Set<Option>().Update(option);

        return option;
    }
}
