using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Commands.Create;

public sealed record CreateProjectCommand : IRequest<Result<Unit>>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public required string SeoUrl { get; init; }
    public required string Client { get; init; }
    public required string Location { get; init; }
    public required int DisplayOrder { get; init; }
} 