using FluentValidation;

namespace OnAlCompany.Application.Features.Services.Commands.Create;

public sealed class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.IconUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.SeoUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.DisplayOrder)
            .NotEmpty();
    }
} 