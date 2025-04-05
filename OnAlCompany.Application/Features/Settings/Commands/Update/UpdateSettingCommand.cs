using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Commands.Update;

public sealed record UpdateSettingCommand : IRequest<Result<Unit>>
{
    public int Id { get; init; }
    public required string CompanyName { get; init; }
    public required string Address { get; init; }
    public required string Phone { get; init; }
    public required string Email { get; init; }
    public required string FacebookUrl { get; init; }
    public required string TwitterUrl { get; init; }
    public required string LinkedInUrl { get; init; }
    public required string InstagramUrl { get; init; }
    public required string LogoUrl { get; init; }
    public required string FooterText { get; init; }
} 