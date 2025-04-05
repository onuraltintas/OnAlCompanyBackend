using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.References.Commands.Delete;

public sealed record DeleteReferenceCommand(int Id) : IRequest<Result<Unit>>; 