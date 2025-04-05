using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Queries.GetAll;

public sealed class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, Result<List<GetAllTeamsQueryResponse>>>
{
    private readonly IRepository<Team, int> _repository;
    private readonly IMapper _mapper;

    public GetAllTeamsQueryHandler(IRepository<Team, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllTeamsQueryResponse>>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllTeamsQueryResponse>>(teams);
        return Result<List<GetAllTeamsQueryResponse>>.Succeed(response);
    }
} 