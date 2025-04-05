using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Commands.Delete;

public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<Unit>>
{
    private readonly IRepository<Category, int> _repository;

    public DeleteCategoryCommandHandler(IRepository<Category, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
        {
            return Result<Unit>.Failure("Category not found!");
        }

        await _repository.RemoveAsync(category, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 