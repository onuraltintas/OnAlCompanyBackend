using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Commands.Create;

public sealed class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<Unit>>
{
    private readonly IRepository<Contact, int> _repository;

    public CreateContactCommandHandler(IRepository<Contact, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Name = request.Name,
            Email = request.Email,
            Subject = request.Subject,
            Message = request.Message,
            Phone = request.Phone,
            CompanyName = request.CompanyName,
            Department = request.Department
        };

        await _repository.AddAsync(contact, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 