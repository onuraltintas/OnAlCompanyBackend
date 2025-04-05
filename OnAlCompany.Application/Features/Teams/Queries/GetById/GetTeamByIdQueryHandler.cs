using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Queries.GetById;

public sealed class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Result<GetTeamByIdQueryResponse>>
{
    private readonly IRepository<Team, int> _repository;
    private readonly IMapper _mapper;

    public GetTeamByIdQueryHandler(IRepository<Team, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetTeamByIdQueryResponse>> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (team is null)
        {
            return Result<GetTeamByIdQueryResponse>.Failure("Team member not found!");
        }

        var response = _mapper.Map<GetTeamByIdQueryResponse>(team);
        return Result<GetTeamByIdQueryResponse>.Succeed(response);
    }
} 