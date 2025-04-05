using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Teams.Queries.GetAll;
using OnAlCompany.Application.Features.Teams.Queries.GetById;

namespace OnAlCompany.Application.Features.Teams.Mapping;

public sealed class TeamMapping : Profile
{
    public TeamMapping()
    {
        CreateMap<Team, GetAllTeamsQueryResponse>();
        CreateMap<Team, GetTeamByIdQueryResponse>();
    }
} 