using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Queries.GetAll;

public sealed record GetAllAboutsQuery : IRequest<Result<List<GetAllAboutsQueryResponse>>>;

public sealed record GetAllAboutsQueryResponse(
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