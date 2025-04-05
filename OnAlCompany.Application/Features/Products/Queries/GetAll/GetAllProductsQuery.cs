using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Queries.GetAll;

public sealed record GetAllProductsQuery : IRequest<Result<List<GetAllProductsQueryResponse>>>;

public sealed record GetAllProductsQueryResponse(
    int Id,
    string Name,
    string Description,
    string Features,
    string ImageUrl,
    string SeoUrl,
    int CategoryId,
    string CategoryName,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate); 