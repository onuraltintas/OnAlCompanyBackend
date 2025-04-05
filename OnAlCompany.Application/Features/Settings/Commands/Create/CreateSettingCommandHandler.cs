using MediatR;
using OnalCompany.Domain.Repositories;
using TS.Result;
using OnalCompany.Domain.Entities;

namespace OnAlCompany.Application.Features.Settings.Commands.Create;

public sealed class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand, Result<Unit>>
{
    private readonly IRepository<SiteSettings, int> _repository;

    public CreateSettingCommandHandler(IRepository<SiteSettings, int> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
    {
        var setting = new SiteSettings
        {
            CompanyName = request.CompanyName,
            Address = request.Address,
            Phone = request.Phone,
            Email = request.Email,
            FacebookUrl = request.FacebookUrl,
            TwitterUrl = request.TwitterUrl,
            LinkedInUrl = request.LinkedInUrl,
            InstagramUrl = request.InstagramUrl,
            LogoUrl = request.LogoUrl,
            FooterText = request.FooterText
        };

        await _repository.AddAsync(setting, cancellationToken);
        return Result<Unit>.Succeed(Unit.Value);
    }
} 