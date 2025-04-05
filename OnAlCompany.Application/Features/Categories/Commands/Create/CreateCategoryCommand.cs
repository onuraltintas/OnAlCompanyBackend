using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Commands.Create;

public sealed record CreateCategoryCommand(
    string Name,
    string Description,
    string ImageUrl,
    string SeoUrl,
    int? ParentId,
    int DisplayOrder) : IRequest<Result<Unit>>; 