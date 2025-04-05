using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Commands.Update;

public sealed record UpdateServiceCommand : IRequest<Result<Unit>>
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public required string IconUrl { get; init; }
    public required string SeoUrl { get; init; }
    public required int DisplayOrder { get; init; }
    public required bool IsActive { get; init; }
} 