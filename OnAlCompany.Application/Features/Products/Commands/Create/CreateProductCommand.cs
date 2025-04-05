using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Commands.Create;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string Features,
    string ImageUrl,
    string SeoUrl,
    int CategoryId,
    int DisplayOrder) : IRequest<Result<Unit>>; 

    