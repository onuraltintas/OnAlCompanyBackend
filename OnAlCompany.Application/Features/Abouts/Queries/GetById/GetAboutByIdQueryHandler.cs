using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Queries.GetById;

public sealed class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, Result<GetAboutByIdQueryResponse>>
{
    private readonly IRepository<About, int> _repository;
    private readonly IMapper _mapper;

    public GetAboutByIdQueryHandler(IRepository<About, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetAboutByIdQueryResponse>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
    {
        var about = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (about is null)
        {
            return Result<GetAboutByIdQueryResponse>.Failure("About not found!");
        }

        var response = _mapper.Map<GetAboutByIdQueryResponse>(about);
        return Result<GetAboutByIdQueryResponse>.Succeed(response);
    }
} 