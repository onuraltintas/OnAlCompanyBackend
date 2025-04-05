using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Queries.GetById;

public sealed class GetSettingByIdQueryHandler : IRequestHandler<GetSettingByIdQuery, Result<GetSettingByIdQueryResponse>>
{
    private readonly IRepository<SiteSettings, int> _repository;
    private readonly IMapper _mapper;

    public GetSettingByIdQueryHandler(IRepository<SiteSettings, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetSettingByIdQueryResponse>> Handle(GetSettingByIdQuery request, CancellationToken cancellationToken)
    {
        var setting = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (setting is null)
        {
            return Result<GetSettingByIdQueryResponse>.Failure("Setting not found!");
        }

        var response = _mapper.Map<GetSettingByIdQueryResponse>(setting);
        return Result<GetSettingByIdQueryResponse>.Succeed(response);
    }
} 