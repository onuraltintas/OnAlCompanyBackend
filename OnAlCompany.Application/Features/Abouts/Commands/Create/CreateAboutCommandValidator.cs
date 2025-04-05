using FluentValidation;

namespace OnAlCompany.Application.Features.Abouts.Commands.Create;

public sealed class CreateAboutCommandValidator : AbstractValidator<CreateAboutCommand>
{
    public CreateAboutCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.SeoUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Vision)
            .NotEmpty();

        RuleFor(x => x.Mission)
            .NotEmpty();
    }
} 