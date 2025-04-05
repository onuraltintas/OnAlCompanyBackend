using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Queries.GetById;

public sealed record GetSettingByIdQuery(int Id) : IRequest<Result<GetSettingByIdQueryResponse>>;

public sealed record GetSettingByIdQueryResponse(
    int Id,
    string Name,
    string Value,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 