using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Commands.Delete;

public sealed class DeleteAboutCommandHandler(IRepository<About, int> repository) : IRequestHandler<DeleteAboutCommand, Result<Unit>>
{
    private readonly IRepository<About, int> _repository = repository;

    public async Task<Result<Unit>> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
    {
        var about = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (about is null)
        {
            return Result<Unit>.Failure("About not found!");
        }

        await _repository.RemoveAsync(about, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 