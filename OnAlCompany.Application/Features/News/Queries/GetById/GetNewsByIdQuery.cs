using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Queries.GetById;

public sealed record GetNewsByIdQuery(int Id) : IRequest<Result<GetNewsByIdQueryResponse>>;

public sealed record GetNewsByIdQueryResponse(
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