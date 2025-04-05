using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Commands.Update;

public sealed record UpdateProductCommand(
    int Id,
    string Name,
    string Description,
    string Features,
    string ImageUrl,
    string SeoUrl,
    int CategoryId,
    int DisplayOrder,
    bool IsActive) : IRequest<Result<Unit>>; 