using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Commands.Update;

public sealed record UpdateReferenceCommand : IRequest<Result<Unit>>
{
    public int Id { get; init; }
    public required string CompanyName { get; init; }
    public required string Description { get; init; }
    public required string LogoUrl { get; init; }
    public required string WebsiteUrl { get; init; }
    public required int DisplayOrder { get; init; }
    public required bool IsActive { get; init; }
} 