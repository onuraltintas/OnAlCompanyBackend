using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Commands.Create;

public sealed record CreateAboutCommand(
    string Title,
    string Description,
    string ImageUrl,
    string SeoUrl,
    string Vision,
    string Mission,
    int DisplayOrder) : IRequest<Result<Unit>>;