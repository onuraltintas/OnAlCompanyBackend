using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Products.Commands.Delete;

public sealed record DeleteProductCommand(int Id) : IRequest<Result<Unit>>; 