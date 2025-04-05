using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Commands.Delete;

public sealed class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Result<Unit>>
{
    private readonly IRepository<Service, int> _repository;

    public DeleteServiceCommandHandler(IRepository<Service, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (service is null)
        {
            return Result<Unit>.Failure("Service not found!");
        }

        await _repository.RemoveAsync(service, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 