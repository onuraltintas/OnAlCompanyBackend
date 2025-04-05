using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Commands.Update;

public sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Result<Unit>>
{
    private readonly IRepository<Project, int> _repository;

    public UpdateProjectCommandHandler(IRepository<Project, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (project is null)
        {
            return Result<Unit>.Failure("Project not found!");
        }

        project.Title = request.Title;
        project.Description = request.Description;
        project.ImageUrl = request.ImageUrl;
        project.SeoUrl = request.SeoUrl;
        project.Client = request.Client;
        project.Location = request.Location;
        project.DisplayOrder = request.DisplayOrder;
        project.IsActive = request.IsActive;

        await _repository.UpdateAsync(project, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 