using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Queries.GetById;

public sealed class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Result<GetServiceByIdQueryResponse>>
{
    private readonly IRepository<Service, int> _repository;
    private readonly IMapper _mapper;

    public GetServiceByIdQueryHandler(IRepository<Service, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetServiceByIdQueryResponse>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (service is null)
        {
            return Result<GetServiceByIdQueryResponse>.Failure("Service not found!");
        }

        var response = _mapper.Map<GetServiceByIdQueryResponse>(service);
        return Result<GetServiceByIdQueryResponse>.Succeed(response);
    }
} 