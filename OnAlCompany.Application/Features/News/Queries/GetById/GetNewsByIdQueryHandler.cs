using AutoMapper;
using MediatR;
using OnalCompany.Domain.Repositories;
using TS.Result;
using OnalCompany.Domain.Entities;

namespace OnAlCompany.Application.Features.News.Queries.GetById;

public sealed class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, Result<GetNewsByIdQueryResponse>>
{
    private readonly IRepository<NewsItem, int> _repository;
    private readonly IMapper _mapper;

    public GetNewsByIdQueryHandler(IRepository<NewsItem, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetNewsByIdQueryResponse>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (news is null)
        {
            return Result<GetNewsByIdQueryResponse>.Failure("News not found!");
        }

        var response = _mapper.Map<GetNewsByIdQueryResponse>(news);
        return Result<GetNewsByIdQueryResponse>.Succeed(response);
    }
} 