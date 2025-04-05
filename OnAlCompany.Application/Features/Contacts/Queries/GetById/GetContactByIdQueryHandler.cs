using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Queries.GetById;

public sealed class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Result<GetContactByIdQueryResponse>>
{
    private readonly IRepository<Contact, int> _repository;
    private readonly IMapper _mapper;

    public GetContactByIdQueryHandler(IRepository<Contact, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetContactByIdQueryResponse>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (contact is null)
        {
            return Result<GetContactByIdQueryResponse>.Failure("Contact not found!");
        }

        var response = _mapper.Map<GetContactByIdQueryResponse>(contact);
        return Result<GetContactByIdQueryResponse>.Succeed(response);
    }
} 