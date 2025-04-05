using FluentValidation;

namespace OnAlCompany.Application.Features.Contacts.Commands.Update;

public sealed class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(100)
            .EmailAddress();

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Subject)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Message)
            .NotEmpty();

        RuleFor(x => x.CompanyName)
            .MaximumLength(200);

        RuleFor(x => x.Department)
            .MaximumLength(100);

        RuleFor(x => x.ReadDate)
            .Must((model, readDate) => !readDate.HasValue || model.IsRead)
            .WithMessage("Read date can only be set when the message is marked as read.");
    }
} 