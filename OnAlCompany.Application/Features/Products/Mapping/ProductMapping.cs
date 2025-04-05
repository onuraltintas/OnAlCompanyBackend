using AutoMapper;
using OnalCompany.Domain.Entities;
using OnAlCompany.Application.Features.Products.Queries.GetAll;
using OnAlCompany.Application.Features.Products.Queries.GetById;

namespace OnAlCompany.Application.Features.Products.Mapping;

public sealed class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, GetAllProductsQueryResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));

        CreateMap<Product, GetProductByIdQueryResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));
    }
} 