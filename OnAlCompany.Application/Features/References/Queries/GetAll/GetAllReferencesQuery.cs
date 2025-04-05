using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Queries.GetAll;

public sealed record GetAllReferencesQuery : IRequest<Result<List<GetAllReferencesQueryResponse>>>;

public sealed record GetAllReferencesQueryResponse(
  int Id,
    string CompanyName,
    string Description,
    string LogoUrl,
    string WebsiteUrl,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);

