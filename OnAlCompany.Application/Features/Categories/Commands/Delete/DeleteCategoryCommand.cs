using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(int Id) : IRequest<Result<Unit>>; 