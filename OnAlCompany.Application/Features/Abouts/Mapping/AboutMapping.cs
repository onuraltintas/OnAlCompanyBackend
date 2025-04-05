using AutoMapper;
using OnAlCompany.Application.Features.Abouts.Queries.GetAll;
using OnAlCompany.Application.Features.Abouts.Queries.GetById;

namespace OnAlCompany.Application.Features.Abouts.Mapping;

public sealed class AboutMapping : Profile
{
    public AboutMapping()
    {
        CreateMap<About, GetAllAboutsQueryResponse>();
        CreateMap<About, GetAboutByIdQueryResponse>();
    }
} 