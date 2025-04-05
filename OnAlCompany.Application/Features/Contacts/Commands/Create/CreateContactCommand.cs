using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Commands.Create;

public sealed record CreateContactCommand(
    string Name,
    string Email,
    string Phone,
    string Subject,
    string Message,
    string CompanyName,
    string Department) : IRequest<Result<Unit>>; 