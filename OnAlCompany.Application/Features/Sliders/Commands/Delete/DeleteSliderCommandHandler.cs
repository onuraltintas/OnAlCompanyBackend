using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Commands.Delete;

public sealed class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand, Result<Unit>>
{
    private readonly IRepository<Slider, int> _repository;

    public DeleteSliderCommandHandler(IRepository<Slider, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (slider is null)
        {
            return Result<Unit>.Failure("Slider not found!");
        }

        await _repository.RemoveAsync(slider, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 