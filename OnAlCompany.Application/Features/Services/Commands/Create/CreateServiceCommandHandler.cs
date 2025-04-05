using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Commands.Create;

public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Result<Unit>>
{
    private readonly IRepository<Service, int> _repository;

    public CreateServiceCommandHandler(IRepository<Service, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            IconUrl = request.IconUrl,
            SeoUrl = request.SeoUrl,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(service, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 