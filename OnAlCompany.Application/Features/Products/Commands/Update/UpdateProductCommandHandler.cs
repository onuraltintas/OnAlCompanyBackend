using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Commands.Update;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Unit>>
{
    private readonly IRepository<Product, int> _repository;
    private readonly IRepository<Category, int> _categoryRepository;

    public UpdateProductCommandHandler(
        IRepository<Product, int> repository,
        IRepository<Category, int> categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
        {
            return Result<Unit>.Failure("Product not found!");
        }

        var categoryExists = await _categoryRepository.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
        if (!categoryExists)
        {
            return Result<Unit>.Failure("Category not found!");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Features = request.Features;
        product.ImageUrl = request.ImageUrl;
        product.SeoUrl = request.SeoUrl;
        product.CategoryId = request.CategoryId;
        product.DisplayOrder = request.DisplayOrder;
        product.IsActive = request.IsActive;

        await _repository.UpdateAsync(product, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 