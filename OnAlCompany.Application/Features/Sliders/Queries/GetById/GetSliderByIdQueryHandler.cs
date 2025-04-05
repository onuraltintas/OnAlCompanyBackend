using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Queries.GetById;

public sealed class GetSliderByIdQueryHandler : IRequestHandler<GetSliderByIdQuery, Result<GetSliderByIdQueryResponse>>
{
    private readonly IRepository<Slider, int> _repository;
    private readonly IMapper _mapper;

    public GetSliderByIdQueryHandler(IRepository<Slider, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetSliderByIdQueryResponse>> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (slider is null)
        {
            return Result<GetSliderByIdQueryResponse>.Failure("Slider not found!");
        }

        var response = _mapper.Map<GetSliderByIdQueryResponse>(slider);
        return Result<GetSliderByIdQueryResponse>.Succeed(response);
    }
} 