using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Queries.GetById;

public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdQueryResponse>>
{
    private readonly IRepository<Category, int> _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IRepository<Category, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetCategoryByIdQueryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
        {
            return Result<GetCategoryByIdQueryResponse>.Failure("Category not found!");
        }

        var response = _mapper.Map<GetCategoryByIdQueryResponse>(category);
        return Result<GetCategoryByIdQueryResponse>.Succeed(response);
    }
} 