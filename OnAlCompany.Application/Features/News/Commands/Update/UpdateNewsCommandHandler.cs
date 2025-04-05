using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Commands.Update;

public sealed class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Result<Unit>>
{
    private readonly IRepository<NewsItem, int> _repository;

    public UpdateNewsCommandHandler(IRepository<NewsItem, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (news is null)
        {
            return Result<Unit>.Failure("News not found!");
        }

        news.Title = request.Title;
        news.Content = request.Content;
        news.ImageUrl = request.ImageUrl;
        news.SeoUrl = request.SeoUrl;
        news.DisplayOrder = request.DisplayOrder;
        news.IsActive = request.IsActive;

        await _repository.UpdateAsync(news, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 