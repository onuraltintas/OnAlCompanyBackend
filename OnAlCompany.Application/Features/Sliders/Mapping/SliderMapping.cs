using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Sliders.Queries.GetAll;
using OnAlCompany.Application.Features.Sliders.Queries.GetById;

namespace OnAlCompany.Application.Features.Sliders.Mapping;

public sealed class SliderMapping : Profile
{
    public SliderMapping()
    {
        CreateMap<Slider, GetAllSlidersQueryResponse>();
        CreateMap<Slider, GetSliderByIdQueryResponse>();
    }
} 