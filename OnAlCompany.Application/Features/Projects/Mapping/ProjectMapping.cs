using AutoMapper;
using OnAlCompany.Application.Features.Projects.Queries.GetAll;
using OnAlCompany.Application.Features.Projects.Queries.GetById;

namespace OnAlCompany.Application.Features.Projects.Mapping;

public sealed class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<Project, GetAllProjectsQueryResponse>();
        CreateMap<Project, GetProjectByIdQueryResponse>();
    }
} 