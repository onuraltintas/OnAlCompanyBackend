using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Queries.GetAll;

public sealed class GetAllSlidersQueryHandler : IRequestHandler<GetAllSlidersQuery, Result<List<GetAllSlidersQueryResponse>>>
{
    private readonly IRepository<Slider, int> _repository;
    private readonly IMapper _mapper;

    public GetAllSlidersQueryHandler(IRepository<Slider, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllSlidersQueryResponse>>> Handle(GetAllSlidersQuery request, CancellationToken cancellationToken)
    {
        var sliders = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllSlidersQueryResponse>>(sliders);
        return Result<List<GetAllSlidersQueryResponse>>.Succeed(response);
    }
} 