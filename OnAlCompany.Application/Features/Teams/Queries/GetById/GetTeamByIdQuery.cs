using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Queries.GetById;

public sealed record GetTeamByIdQuery(int Id) : IRequest<Result<GetTeamByIdQueryResponse>>;

public sealed record GetTeamByIdQueryResponse(
    int Id,
    string FullName,
    string Title,
    string Description,
    string ImageUrl,
    string SeoUrl,
    string Email,
    string Phone,
    string LinkedIn,
    string Twitter,
    string Instagram,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 