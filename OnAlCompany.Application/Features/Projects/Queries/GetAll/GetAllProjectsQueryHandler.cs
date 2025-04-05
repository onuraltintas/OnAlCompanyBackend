using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Queries.GetAll;

public sealed class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, Result<List<GetAllProjectsQueryResponse>>>
{
    private readonly IRepository<Project, int> _repository;
    private readonly IMapper _mapper;

    public GetAllProjectsQueryHandler(IRepository<Project, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllProjectsQueryResponse>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAll()
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllProjectsQueryResponse>>(projects);
        return Result<List<GetAllProjectsQueryResponse>>.Succeed(response);
    }
} 