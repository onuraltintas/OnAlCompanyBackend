using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Queries.GetAll;

public sealed record GetAllContactsQuery : IRequest<Result<List<GetAllContactsQueryResponse>>>;

public sealed record GetAllContactsQueryResponse(
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