using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Commands.Update;

public sealed class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, Result<Unit>>
{
    private readonly IRepository<Team, int> _repository;

    public UpdateTeamCommandHandler(IRepository<Team, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (team is null)
        {
            return Result<Unit>.Failure("Team member not found!");
        }

        var emailExists = await _repository.AnyAsync(x => x.Email == request.Email && x.Id != request.Id, cancellationToken);
        if (emailExists)
        {
            return Result<Unit>.Failure("Team member with this email already exists!");
        }

        team.FullName = request.FullName;
        team.Title = request.Title;
        team.Description = request.Description;
        team.ImageUrl = request.ImageUrl;
        team.SeoUrl = request.SeoUrl;
        team.Email = request.Email;
        team.Phone = request.Phone;
        team.LinkedIn = request.LinkedIn;
        team.Twitter = request.Twitter;
        team.Instagram = request.Instagram;
        team.DisplayOrder = request.DisplayOrder;
        team.IsActive = request.IsActive;

        await _repository.UpdateAsync(team, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 