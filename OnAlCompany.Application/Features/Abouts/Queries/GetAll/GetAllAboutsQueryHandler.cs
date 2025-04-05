using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Queries.GetAll;

public sealed class GetAllAboutsQueryHandler : IRequestHandler<GetAllAboutsQuery, Result<List<GetAllAboutsQueryResponse>>>
{
    private readonly IRepository<About, int> _repository;
    private readonly IMapper _mapper;

    public GetAllAboutsQueryHandler(IRepository<About, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllAboutsQueryResponse>>> Handle(GetAllAboutsQuery request, CancellationToken cancellationToken)
    {
        var abouts = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllAboutsQueryResponse>>(abouts);
        return Result<List<GetAllAboutsQueryResponse>>.Succeed(response);
    }
} 