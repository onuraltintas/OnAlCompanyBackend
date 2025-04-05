using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Queries.GetAll;

public sealed record GetAllTeamsQuery : IRequest<Result<List<GetAllTeamsQueryResponse>>>;

public sealed record GetAllTeamsQueryResponse(
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