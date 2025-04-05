using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Commands.Update;

public sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result<Unit>>
{
    private readonly IRepository<Contact, int> _repository;

    public UpdateContactCommandHandler(IRepository<Contact, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (contact is null)
        {
            return Result<Unit>.Failure("Contact not found!");
        }

        contact.Name = request.Name;
        contact.Email = request.Email;
        contact.Subject = request.Subject;
        contact.Message = request.Message;
        contact.Phone = request.Phone;
        contact.IsActive = request.IsActive;

        await _repository.UpdateAsync(contact, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 