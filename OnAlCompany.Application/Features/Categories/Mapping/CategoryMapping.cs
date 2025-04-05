using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Categories.Queries.GetAll;
using OnAlCompany.Application.Features.Categories.Queries.GetById;

namespace OnAlCompany.Application.Features.Categories.Mapping;

public sealed class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, GetAllCategoriesQueryResponse>()
            .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.Name : null))
            .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));

        CreateMap<Category, GetCategoryByIdQueryResponse>()
            .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.Name : null))
            .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(src => src.SubCategories));
    }
} 