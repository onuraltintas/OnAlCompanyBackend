using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Queries.GetAll;

public sealed class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, Result<List<GetAllContactsQueryResponse>>>
{
    private readonly IRepository<Contact, int> _repository;
    private readonly IMapper _mapper;

    public GetAllContactsQueryHandler(IRepository<Contact, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllContactsQueryResponse>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _repository.GetAll()
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllContactsQueryResponse>>(contacts);
        return Result<List<GetAllContactsQueryResponse>>.Succeed(response);
    }
} 