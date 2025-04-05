using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Commands.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Unit>>
{
    private readonly IRepository<Category, int> _repository;

    public CreateCategoryCommandHandler(IRepository<Category, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
            Description = request.Description,
            SeoUrl = request.SeoUrl,
            ImageUrl = request.ImageUrl,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(category, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 