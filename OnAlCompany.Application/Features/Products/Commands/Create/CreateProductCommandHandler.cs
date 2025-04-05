using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Commands.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Unit>>
{
    private readonly IRepository<Product, int> _repository;
    private readonly IRepository<Category, int> _categoryRepository;

    public CreateProductCommandHandler(
        IRepository<Product, int> repository,
        IRepository<Category, int> categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var categoryExists = await _categoryRepository.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
        if (!categoryExists)
        {
            return Result<Unit>.Failure("Category not found!");
        }

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Features = request.Features,
            ImageUrl = request.ImageUrl,
            SeoUrl = request.SeoUrl,
            CategoryId = request.CategoryId,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(product, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 