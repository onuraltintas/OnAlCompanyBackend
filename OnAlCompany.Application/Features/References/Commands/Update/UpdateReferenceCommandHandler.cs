using MediatR;
using OnalCompany.Domain.Entities;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Commands.Update;

public sealed class UpdateReferenceCommandHandler : IRequestHandler<UpdateReferenceCommand, Result<Unit>>
{
    private readonly IRepository<Reference, int> _repository;

    public UpdateReferenceCommandHandler(IRepository<Reference, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateReferenceCommand request, CancellationToken cancellationToken)
    {
        var reference = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (reference is null)
        {
            return Result<Unit>.Failure("Reference not found!");
        }

        reference.CompanyName = request.CompanyName;
        reference.Description = request.Description;
        reference.LogoUrl = request.LogoUrl;
        reference.WebsiteUrl = request.WebsiteUrl;
        reference.DisplayOrder = request.DisplayOrder;
        reference.IsActive = request.IsActive;

        await _repository.UpdateAsync(reference, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 