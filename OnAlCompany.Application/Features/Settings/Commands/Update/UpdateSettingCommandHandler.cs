using MediatR;
using OnalCompany.Domain.Repositories;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Commands.Update;

public sealed class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, Result<Unit>>
{
    private readonly IRepository<SiteSettings, int> _repository;

    public UpdateSettingCommandHandler(IRepository<SiteSettings, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
    {
        var setting = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (setting is null)
        {
            return Result<Unit>.Failure("Setting not found!");
        }

        setting.CompanyName = request.CompanyName;
        setting.Address = request.Address;
        setting.Phone = request.Phone;
        setting.Email = request.Email;
        setting.FacebookUrl = request.FacebookUrl;
        setting.TwitterUrl = request.TwitterUrl;
        setting.LinkedInUrl = request.LinkedInUrl;
        setting.InstagramUrl = request.InstagramUrl;
        setting.LogoUrl = request.LogoUrl;
        setting.FooterText = request.FooterText;

        await _repository.UpdateAsync(setting, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 