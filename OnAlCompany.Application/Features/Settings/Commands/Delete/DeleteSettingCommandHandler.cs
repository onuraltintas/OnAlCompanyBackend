using MediatR;
using OnalCompany.Domain.Repositories;
using TS.Result;
using OnalCompany.Domain.Entities;

namespace OnAlCompany.Application.Features.Settings.Commands.Delete;

public sealed class DeleteSettingCommandHandler : IRequestHandler<DeleteSettingCommand, Result<Unit>>
{
    private readonly IRepository<SiteSettings, int> _repository;

    public DeleteSettingCommandHandler(IRepository<SiteSettings, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteSettingCommand request, CancellationToken cancellationToken)
    {
        var setting = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (setting is null)
        {
            return Result<Unit>.Failure("Setting not found!");
        }

        await _repository.RemoveAsync(setting, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 