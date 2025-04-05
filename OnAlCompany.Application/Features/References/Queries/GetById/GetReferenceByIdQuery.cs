using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Queries.GetAll;

public sealed record GetReferenceByIdQuery(int Id) : IRequest<Result<GetReferenceByIdQueryResponse>>;

public sealed record GetReferenceByIdQueryResponse(
    int Id,
    string CompanyName,
    string Description,
    string LogoUrl,
    string WebsiteUrl,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);

