using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Commands.Update;

public sealed class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, Result<Unit>>
{
    private readonly IRepository<Slider, int> _repository;

    public UpdateSliderCommandHandler(IRepository<Slider, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (slider is null)
        {
            return Result<Unit>.Failure("Slider not found!");
        }

        slider.Title = request.Title;
        slider.Description = request.Description;
        slider.ImageUrl = request.ImageUrl;
        slider.ButtonText = request.ButtonText;
        slider.ButtonUrl = request.ButtonUrl;
        slider.DisplayOrder = request.DisplayOrder;
        slider.IsActive = request.IsActive;

        await _repository.UpdateAsync(slider, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 