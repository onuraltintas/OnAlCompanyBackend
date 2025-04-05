using FluentValidation;

namespace OnAlCompany.Application.Features.Projects.Commands.Create;

public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.SeoUrl)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Client)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Location)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DisplayOrder)
            .NotEmpty();
    }
} 