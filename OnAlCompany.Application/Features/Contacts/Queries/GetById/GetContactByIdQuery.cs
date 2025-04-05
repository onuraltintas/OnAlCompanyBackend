using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Queries.GetById;

public sealed record GetContactByIdQuery(int Id) : IRequest<Result<GetContactByIdQueryResponse>>;

public sealed record GetContactByIdQueryResponse(
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
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 