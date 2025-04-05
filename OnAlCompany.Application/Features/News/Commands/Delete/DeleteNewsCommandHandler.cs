using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Commands.Delete;

public sealed class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Result<Unit>>
{
    private readonly IRepository<NewsItem, int> _repository;

    public DeleteNewsCommandHandler(IRepository<NewsItem, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (news is null)
        {
            return Result<Unit>.Failure("News not found!");
        }

        await _repository.RemoveAsync(news, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 