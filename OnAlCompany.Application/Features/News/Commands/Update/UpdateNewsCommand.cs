using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Commands.Update;

public sealed record UpdateNewsCommand(
    int Id,
    string Title,
    string Content,
    string ImageUrl,
    string SeoUrl,
    DateTime PublishDate,
    int DisplayOrder,
    bool IsActive) : IRequest<Result<Unit>>; 