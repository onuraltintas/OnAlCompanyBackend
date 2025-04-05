using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Commands.Delete;

public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Result<Unit>>
{
    private readonly IRepository<Project, int> _repository;

    public DeleteProjectCommandHandler(IRepository<Project, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (project is null)
        {
            return Result<Unit>.Failure("Project not found!");
        }

        await _repository.RemoveAsync(project, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 