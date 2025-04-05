using FluentValidation;

namespace OnAlCompany.Application.Features.Settings.Commands.Update;

public sealed class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
{
    public UpdateSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(x => x.FacebookUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.TwitterUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.LinkedInUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.InstagramUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.LogoUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.FooterText)
            .NotEmpty()
            .MaximumLength(500);
    }
} 