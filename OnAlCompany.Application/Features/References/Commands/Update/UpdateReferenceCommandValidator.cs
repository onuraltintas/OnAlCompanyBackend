using FluentValidation;

namespace OnAlCompany.Application.Features.References.Commands.Update;

public sealed class UpdateReferenceCommandValidator : AbstractValidator<UpdateReferenceCommand>
{
    public UpdateReferenceCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

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