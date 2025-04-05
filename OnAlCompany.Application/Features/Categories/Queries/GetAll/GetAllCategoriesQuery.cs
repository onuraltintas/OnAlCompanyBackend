using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Queries.GetAll;

public sealed record GetAllCategoriesQuery : IRequest<Result<List<GetAllCategoriesQueryResponse>>>;

public sealed record GetAllCategoriesQueryResponse(
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
    List<GetAllCategoriesQueryResponse> SubCategories); 