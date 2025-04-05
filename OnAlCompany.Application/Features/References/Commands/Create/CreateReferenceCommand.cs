using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Commands.Create;

public sealed record CreateReferenceCommand : IRequest<Result<Unit>>
{
    public required string CompanyName { get; init; }
    public required string Description { get; init; }
    public required string LogoUrl { get; init; }
    public required string WebsiteUrl { get; init; }
    public required int DisplayOrder { get; init; }
} 