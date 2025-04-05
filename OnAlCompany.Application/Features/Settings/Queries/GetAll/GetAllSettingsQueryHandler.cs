using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Queries.GetAll;

public sealed class GetAllSettingsQueryHandler : IRequestHandler<GetAllSettingsQuery, Result<List<GetAllSettingsQueryResponse>>>
{
    private readonly IRepository<SiteSettings, int> _repository;
    private readonly IMapper _mapper;

    public GetAllSettingsQueryHandler(IRepository<SiteSettings, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllSettingsQueryResponse>>> Handle(GetAllSettingsQuery request, CancellationToken cancellationToken)
    {
        var settings = await _repository.GetAll()
            .OrderBy(x => x.CompanyName)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllSettingsQueryResponse>>(settings);
        return Result<List<GetAllSettingsQueryResponse>>.Succeed(response);
    }
} 