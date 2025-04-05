using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Commands.Create;

public sealed record CreateTeamCommand(
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
    int DisplayOrder) : IRequest<Result<Unit>>; 