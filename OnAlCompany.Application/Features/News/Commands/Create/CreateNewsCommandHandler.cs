using MediatR;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Commands.Create;

public sealed class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Result<Unit>>
{
    private readonly IRepository<NewsItem, int> _repository;

    public CreateNewsCommandHandler(IRepository<NewsItem, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = new NewsItem
        {
            Title = request.Title,
            Content = request.Content,
            ImageUrl = request.ImageUrl,
            SeoUrl = request.SeoUrl,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(news, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 