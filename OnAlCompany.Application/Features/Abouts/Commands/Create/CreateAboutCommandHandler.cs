using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Commands.Create;

public sealed class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, Result<Unit>>
{
    private readonly IRepository<About, int> _repository;

    public CreateAboutCommandHandler(IRepository<About, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
    {
        var about = new About
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            SeoUrl = request.SeoUrl,
            Vision = request.Vision,
            Mission = request.Mission,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(about, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 