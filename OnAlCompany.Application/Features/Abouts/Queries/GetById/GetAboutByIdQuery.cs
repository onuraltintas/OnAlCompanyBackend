using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Queries.GetById;

public sealed record GetAboutByIdQuery(int Id) : IRequest<Result<GetAboutByIdQueryResponse>>;

public sealed record GetAboutByIdQueryResponse(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string SeoUrl,
    string Vision,
    string Mission,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 