using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Commands.Create;

public sealed record CreateNewsCommand(
    string Title,
    string Content,
    string ImageUrl,
    string SeoUrl,
    DateTime PublishDate,
    int DisplayOrder) : IRequest<Result<Unit>>; 