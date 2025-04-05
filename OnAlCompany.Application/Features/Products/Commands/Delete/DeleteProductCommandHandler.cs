using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Commands.Delete;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<Unit>>
{
    private readonly IRepository<Product, int> _repository;

    public DeleteProductCommandHandler(IRepository<Product, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            return Result<Unit>.Failure("Product not found!");
        }

        await _repository.RemoveAsync(product, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 