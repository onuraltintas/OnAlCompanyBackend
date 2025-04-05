using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Commands.Delete;

public sealed class DeleteReferenceCommandHandler : IRequestHandler<DeleteReferenceCommand, Result<Unit>>
{
    private readonly IRepository<Reference, int> _repository;

    public DeleteReferenceCommandHandler(IRepository<Reference, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteReferenceCommand request, CancellationToken cancellationToken)
    {
        var reference = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (reference is null)
        {
            return Result<Unit>.Failure("Reference not found!");
        }

        await _repository.RemoveAsync(reference, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 