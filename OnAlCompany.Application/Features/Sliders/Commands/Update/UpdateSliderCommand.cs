using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Commands.Update;

public sealed record UpdateSliderCommand : IRequest<Result<Unit>>
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public required string ButtonText { get; init; }
    public required string ButtonUrl { get; init; }
    public required int DisplayOrder { get; init; }
    public required bool IsActive { get; init; }
} 