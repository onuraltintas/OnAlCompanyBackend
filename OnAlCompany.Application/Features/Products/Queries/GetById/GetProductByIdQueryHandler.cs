using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Queries.GetById;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<GetProductByIdQueryResponse>>
{
    private readonly IRepository<Product, int> _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IRepository<Product, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetProductByIdQueryResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetAll()
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return Result<GetProductByIdQueryResponse>.Failure("Product not found!");
        }

        var response = _mapper.Map<GetProductByIdQueryResponse>(product);
        return Result<GetProductByIdQueryResponse>.Succeed(response);
    }
} 