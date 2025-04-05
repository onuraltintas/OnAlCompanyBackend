using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Queries.GetById;

public sealed record GetProjectByIdQuery(int Id) : IRequest<Result<GetProjectByIdQueryResponse>>;

public sealed record GetProjectByIdQueryResponse(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string SeoUrl,
    string Client,
    string Location,
    DateTime ProjectDate,
    int DisplayOrder,   
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);

