using FluentValidation;

namespace OnAlCompany.Application.Features.Sliders.Commands.Create;

public sealed class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
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

        RuleFor(x => x.ButtonText)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.ButtonUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.DisplayOrder)
            .NotEmpty();
    }
} 