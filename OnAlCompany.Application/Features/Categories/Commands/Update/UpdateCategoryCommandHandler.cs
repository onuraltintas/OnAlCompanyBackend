using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Commands.Update;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Unit>>
{
    private readonly IRepository<Category, int> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
        {
            return Result<Unit>.Failure("Category not found!");
        }

        category.Name = request.Name;
        category.Description = request.Description;
        category.SeoUrl = request.SeoUrl;
        category.DisplayOrder = request.DisplayOrder;
        category.IsActive = request.IsActive;

        await _repository.UpdateAsync(category, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 