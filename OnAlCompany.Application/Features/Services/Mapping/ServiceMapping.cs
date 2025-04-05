using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Services.Queries.GetAll;
using OnAlCompany.Application.Features.Services.Queries.GetById;

namespace OnAlCompany.Application.Features.Services.Mapping;

public sealed class ServiceMapping : Profile
{
    public ServiceMapping()
    {
        CreateMap<Service, GetAllServicesQueryResponse>();
        CreateMap<Service, GetServiceByIdQueryResponse>();
    }
} 