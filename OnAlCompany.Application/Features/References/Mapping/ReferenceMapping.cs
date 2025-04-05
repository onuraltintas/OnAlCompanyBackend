using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.References.Queries.GetAll;

namespace OnAlCompany.Application.Features.References.Mapping;

public sealed class ReferenceMapping : Profile
{
    public ReferenceMapping()
    {
        CreateMap<Reference, GetAllReferencesQueryResponse>();
        CreateMap<Reference, GetReferenceByIdQueryResponse>();
    }
} 