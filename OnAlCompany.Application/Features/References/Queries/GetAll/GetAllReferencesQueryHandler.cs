using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Queries.GetAll;

public sealed class GetAllReferencesQueryHandler : IRequestHandler<GetAllReferencesQuery, Result<List<GetAllReferencesQueryResponse>>>
{
    private readonly IRepository<Reference, int> _repository;
    private readonly IMapper _mapper;

    public GetAllReferencesQueryHandler(IRepository<Reference, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllReferencesQueryResponse>>> Handle(GetAllReferencesQuery request, CancellationToken cancellationToken)
    {
        var references = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllReferencesQueryResponse>>(references);
        return Result<List<GetAllReferencesQueryResponse>>.Succeed(response);
    }
} 