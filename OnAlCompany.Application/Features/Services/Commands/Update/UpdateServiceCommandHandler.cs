using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Commands.Update;

public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Result<Unit>>
{
    private readonly IRepository<Service, int> _repository;

    public UpdateServiceCommandHandler(IRepository<Service, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (service is null)
        {
            return Result<Unit>.Failure("Service not found!");
        }

        service.Title = request.Title;
        service.Description = request.Description;
        service.ImageUrl = request.ImageUrl;
        service.IconUrl = request.IconUrl;
        service.SeoUrl = request.SeoUrl;
        service.DisplayOrder = request.DisplayOrder;
        service.IsActive = request.IsActive;

        await _repository.UpdateAsync(service, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 