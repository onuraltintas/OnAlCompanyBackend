using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Settings.Queries.GetAll;
using OnAlCompany.Application.Features.Settings.Queries.GetById;

namespace OnAlCompany.Application.Features.Settings.Mapping;

public sealed class SettingMapping : Profile
{
    public SettingMapping()
    {
        CreateMap<SiteSettings, GetAllSettingsQueryResponse>();
        CreateMap<SiteSettings, GetSettingByIdQueryResponse>();
    }
} 