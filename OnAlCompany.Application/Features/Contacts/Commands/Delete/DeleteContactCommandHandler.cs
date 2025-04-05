using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Commands.Delete;

public sealed class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result<Unit>>
{
    private readonly IRepository<Contact, int> _repository;

    public DeleteContactCommandHandler(IRepository<Contact, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (contact is null)
        {
            return Result<Unit>.Failure("Contact not found!");
        }

        await _repository.RemoveAsync(contact, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 