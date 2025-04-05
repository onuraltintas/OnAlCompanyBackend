using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using OnAlCompany.Application.Features.References.Queries.GetAll;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Queries.GetById;

public sealed class GetReferenceByIdQueryHandler : IRequestHandler<GetReferenceByIdQuery, Result<GetReferenceByIdQueryResponse>>
{
    private readonly IRepository<Reference, int> _repository;
    private readonly IMapper _mapper;

    public GetReferenceByIdQueryHandler(IRepository<Reference, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetReferenceByIdQueryResponse>> Handle(GetReferenceByIdQuery request, CancellationToken cancellationToken)
    {
        var reference = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (reference is null)
        {
            return Result<GetReferenceByIdQueryResponse>.Failure("Reference not found!");
        }

        var response = _mapper.Map<GetReferenceByIdQueryResponse>(reference);
        return Result<GetReferenceByIdQueryResponse>.Succeed(response);
    }
} 