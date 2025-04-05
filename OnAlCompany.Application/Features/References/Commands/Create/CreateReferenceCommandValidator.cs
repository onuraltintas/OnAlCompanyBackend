using FluentValidation;

namespace OnAlCompany.Application.Features.References.Commands.Create;

public sealed class CreateReferenceCommandValidator : AbstractValidator<CreateReferenceCommand>
{
    public CreateReferenceCommandValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.LogoUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.WebsiteUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.DisplayOrder)
            .NotEmpty();
    }
} 