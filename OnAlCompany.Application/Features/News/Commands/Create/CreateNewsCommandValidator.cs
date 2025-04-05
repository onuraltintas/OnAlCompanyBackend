using FluentValidation;

namespace OnAlCompany.Application.Features.News.Commands.Create;

public sealed class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
{
    public CreateNewsCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Content)
            .NotEmpty();

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.SeoUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.PublishDate)
            .NotEmpty()
            .Must(x => x >= DateTime.Today)
            .WithMessage("Publish date must be today or a future date");

        RuleFor(x => x.DisplayOrder)
            .NotEmpty();
    }
} 