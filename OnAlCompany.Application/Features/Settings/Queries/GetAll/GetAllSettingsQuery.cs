using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Queries.GetAll;

public sealed record GetAllSettingsQuery : IRequest<Result<List<GetAllSettingsQueryResponse>>>;

public sealed record GetAllSettingsQueryResponse(
    int Id,
    string Name,
    string Value,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 