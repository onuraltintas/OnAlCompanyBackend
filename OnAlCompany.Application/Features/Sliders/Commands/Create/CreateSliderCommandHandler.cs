using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Commands.Create;

public sealed class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, Result<Unit>>
{
    private readonly IRepository<Slider, int> _repository;

    public CreateSliderCommandHandler(IRepository<Slider, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = new Slider
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            ButtonText = request.ButtonText,
            ButtonUrl = request.ButtonUrl,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(slider, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 