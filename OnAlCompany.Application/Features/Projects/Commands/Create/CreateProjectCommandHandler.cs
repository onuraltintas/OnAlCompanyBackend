using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Commands.Create;

public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<Unit>>
{
    private readonly IRepository<Project, int> _repository;

    public CreateProjectCommandHandler(IRepository<Project, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            SeoUrl = request.SeoUrl,
            Client = request.Client,
            Location = request.Location,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(project, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 