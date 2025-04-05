using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Commands.Update;

public sealed record UpdateCategoryCommand(
    int Id,
    string Name,
    string Description,
    string ImageUrl,
    string SeoUrl,
    int? ParentId,
    int DisplayOrder,
    bool IsActive) : IRequest<Result<Unit>>; 