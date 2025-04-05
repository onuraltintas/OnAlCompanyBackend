using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Commands.Create;

public sealed record CreateServiceCommand : IRequest<Result<Unit>>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public required string IconUrl { get; init; }
    public required string SeoUrl { get; init; }
    public required int DisplayOrder { get; init; }
} 