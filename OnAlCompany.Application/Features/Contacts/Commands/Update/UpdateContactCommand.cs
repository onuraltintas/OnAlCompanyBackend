using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Commands.Update;

public sealed record UpdateContactCommand(
    int Id,
    string Name,
    string Email,
    string Phone,
    string Subject,
    string Message,
    string CompanyName,
    string Department,
    bool IsRead,
    DateTime? ReadDate,
    bool IsActive) : IRequest<Result<Unit>>; 