using MediatR;
using OnalCompany.Domain.Entities;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Queries.GetAll;

public sealed record GetAllProjectsQuery : IRequest<Result<List<GetAllProjectsQueryResponse>>>;

public sealed record GetAllProjectsQueryResponse(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string SeoUrl,
    string Client,
    string Location,
    DateTime ProjectDate,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);

