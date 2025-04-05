using AutoMapper;
using OnAlCompany.Application.Features.News.Queries.GetAll;
using OnAlCompany.Application.Features.News.Queries.GetById;

namespace OnAlCompany.Application.Features.News.Mapping;

public sealed class NewsMapping : Profile
{
    public NewsMapping()
    {
        CreateMap<NewsItem, GetAllNewsQueryResponse>();
        CreateMap<NewsItem, GetNewsByIdQueryResponse>();
    }
} 