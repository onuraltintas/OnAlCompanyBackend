using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Queries.GetById;

public sealed record GetSliderByIdQuery(int Id) : IRequest<Result<GetSliderByIdQueryResponse>>;

public sealed record GetSliderByIdQueryResponse(
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

