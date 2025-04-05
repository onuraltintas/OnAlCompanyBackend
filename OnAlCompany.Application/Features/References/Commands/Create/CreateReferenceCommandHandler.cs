using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Commands.Create;

public sealed class CreateReferenceCommandHandler : IRequestHandler<CreateReferenceCommand, Result<Unit>>
{
    private readonly IRepository<Reference, int> _repository;

    public CreateReferenceCommandHandler(IRepository<Reference, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateReferenceCommand request, CancellationToken cancellationToken)
    {
        var reference = new Reference
        {
            CompanyName = request.CompanyName,
            Description = request.Description,
            LogoUrl = request.LogoUrl,
            WebsiteUrl = request.WebsiteUrl,
            DisplayOrder = request.DisplayOrder
        };

        await _repository.AddAsync(reference, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 