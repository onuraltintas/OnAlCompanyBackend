using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Queries.GetById;

public sealed record GetServiceByIdQuery(int Id) : IRequest<Result<GetServiceByIdQueryResponse>>;

public sealed record GetServiceByIdQueryResponse(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string IconUrl,
    string SeoUrl,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);