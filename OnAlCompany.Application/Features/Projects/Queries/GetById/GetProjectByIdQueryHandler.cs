using AutoMapper;
using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Queries.GetById;

public sealed class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Result<GetProjectByIdQueryResponse>>
{
    private readonly IRepository<Project, int> _repository;
    private readonly IMapper _mapper;

    public GetProjectByIdQueryHandler(IRepository<Project, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetProjectByIdQueryResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (project is null)
        {
            return Result<GetProjectByIdQueryResponse>.Failure("Project not found!");
        }

        var response = _mapper.Map<GetProjectByIdQueryResponse>(project);
        return Result<GetProjectByIdQueryResponse>.Succeed(response);
    }
} 