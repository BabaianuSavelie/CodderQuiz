using Application.Common.Interfaces.Repositories;
using Application.Data;
using Domain.Models;
using Mapster;
using MediatR;

namespace Application.Quizzes.Commands.Create;

public class CreateQuizzCommandHandler : IRequestHandler<CreateQuizzCommand, QuizzResponse>
{
    private readonly IQuizzRepository _quizzRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuizzCommandHandler(IQuizzRepository quizzRepository, IUnitOfWork unitOfWork)
    {
        _quizzRepository = quizzRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<QuizzResponse> Handle(CreateQuizzCommand request, CancellationToken cancellationToken)
    {
        var quizz = new Quizz
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };

        var result = await _quizzRepository.CreateAsync(quizz, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Adapt<QuizzResponse>();
    }
}
