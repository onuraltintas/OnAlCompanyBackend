using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Queries.GetAll;

public sealed class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, Result<List<GetAllNewsQueryResponse>>>
{
    private readonly IRepository<NewsItem, int> _repository;
    private readonly IMapper _mapper;

    public GetAllNewsQueryHandler(IRepository<NewsItem, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllNewsQueryResponse>>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllNewsQueryResponse>>(news);
        return Result<List<GetAllNewsQueryResponse>>.Succeed(response);
    }
} 