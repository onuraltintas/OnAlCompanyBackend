using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Queries.GetById;

public sealed record GetCategoryByIdQuery(int Id) : IRequest<Result<GetCategoryByIdQueryResponse>>;

public sealed record GetCategoryByIdQueryResponse(
    int Id,
    string Name,
    string Description,
    string ImageUrl,
    string SeoUrl,
    int? ParentId,
    string ParentName,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate,
    List<GetCategoryByIdQueryResponse> SubCategories); 