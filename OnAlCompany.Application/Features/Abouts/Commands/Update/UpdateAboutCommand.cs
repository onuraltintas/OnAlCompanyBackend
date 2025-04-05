using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Commands.Update;

public sealed record UpdateAboutCommand(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string SeoUrl,
    string Vision,
    string Mission,
    int DisplayOrder,
    bool IsActive) : IRequest<Result<Unit>>; 