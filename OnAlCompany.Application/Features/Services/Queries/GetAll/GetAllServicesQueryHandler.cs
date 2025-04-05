using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Queries.GetAll;

public sealed class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, Result<List<GetAllServicesQueryResponse>>>
{
    private readonly IRepository<Service, int> _repository;
    private readonly IMapper _mapper;

    public GetAllServicesQueryHandler(IRepository<Service, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllServicesQueryResponse>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllServicesQueryResponse>>(services);
        return Result<List<GetAllServicesQueryResponse>>.Succeed(response);
    }
} 