using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Queries.GetAll;

public sealed record GetAllSlidersQuery : IRequest<Result<List<GetAllSlidersQueryResponse>>>;

public sealed record GetAllSlidersQueryResponse(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string ButtonText,
    string ButtonUrl,
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);