using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Queries.GetAll;

public sealed record GetAllServicesQuery : IRequest<Result<List<GetAllServicesQueryResponse>>>;

public sealed record GetAllServicesQueryResponse(
    int Id,
    string Title,
    string Description,    
    string ImageUrl,
    string IconUrl,
    string SeoUrl,    
    int DisplayOrder,
    bool IsActive,
    DateTime CreatedDate,
    DateTime? UpdatedDate);

