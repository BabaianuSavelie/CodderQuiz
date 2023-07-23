using Application.Common.Interfaces.Repositories;
using Application.Data;
using Domain.Models;
using MediatR;

namespace Application.Categories.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.name
        };

        var result = await _categoryRepository.CreateAsync(category, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }  
}
