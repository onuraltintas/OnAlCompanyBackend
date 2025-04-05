using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Commands.Update;

public sealed class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, Result<Unit>>
{
    private readonly IRepository<About, int> _repository;

    public UpdateAboutCommandHandler(IRepository<About, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
    {
        var about = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (about is null)
        {
            return Result<Unit>.Failure("About not found!");
        }

        about.Title = request.Title;
        about.Description = request.Description;
        about.ImageUrl = request.ImageUrl;
        about.SeoUrl = request.SeoUrl;
        about.Vision = request.Vision;
        about.Mission = request.Mission;
        about.DisplayOrder = request.DisplayOrder;
        about.IsActive = request.IsActive;

        await _repository.UpdateAsync(about, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 