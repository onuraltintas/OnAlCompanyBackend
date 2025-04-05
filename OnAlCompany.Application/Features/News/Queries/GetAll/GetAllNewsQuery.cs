using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Queries.GetAll;

public sealed record GetAllNewsQuery : IRequest<Result<List<GetAllNewsQueryResponse>>>;

public sealed record GetAllNewsQueryResponse(
    int Id,
    string Title,
    string Content,
    string ImageUrl,
    string SeoUrl,
    DateTime PublishDate,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 