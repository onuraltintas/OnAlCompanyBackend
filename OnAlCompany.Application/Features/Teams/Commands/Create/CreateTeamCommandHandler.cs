using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Commands.Create;

public sealed class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Result<Unit>>
{
    private readonly IRepository<Team, int> _repository;

    public CreateTeamCommandHandler(IRepository<Team, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var emailExists = await _repository.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (emailExists)
        {
            return Result<Unit>.Failure("Team member with this email already exists!");
        }

        var team = new Team
        {
            FullName = request.FullName,
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            SeoUrl = request.SeoUrl,
            Email = request.Email,
            Phone = request.Phone,
            LinkedIn = request.LinkedIn,
            Twitter = request.Twitter,
            Instagram = request.Instagram,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(team, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 