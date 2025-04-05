using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Commands.Update;

public sealed record UpdateTeamCommand(
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
    bool IsActive) : IRequest<Result<Unit>>; 