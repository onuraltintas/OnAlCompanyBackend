using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Queries.GetById;

public sealed record GetProductByIdQuery(int Id) : IRequest<Result<GetProductByIdQueryResponse>>;

public sealed record GetProductByIdQueryResponse(
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