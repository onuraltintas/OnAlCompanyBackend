using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Commands.Delete;

public sealed class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, Result<Unit>>
{
    private readonly IRepository<Team, int> _repository;

    public DeleteTeamCommandHandler(IRepository<Team, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (team is null)
        {
            return Result<Unit>.Failure("Team member not found!");
        }

        await _repository.RemoveAsync(team, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 