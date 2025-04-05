using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Queries.GetAll;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<List<GetAllProductsQueryResponse>>>
{
    private readonly IRepository<Product, int> _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IRepository<Product, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllProductsQueryResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAll()
            .Include(x => x.Category)
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllProductsQueryResponse>>(products);
        return Result<List<GetAllProductsQueryResponse>>.Succeed(response);
    }
} 