using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Queries.GetAll;

public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<GetAllCategoriesQueryResponse>>>
{
    private readonly IRepository<Category, int> _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IRepository<Category, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllCategoriesQueryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllCategoriesQueryResponse>>(categories);
        return Result<List<GetAllCategoriesQueryResponse>>.Succeed(response);
    }
} 