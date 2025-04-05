using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Services.Commands.Delete;

public sealed record DeleteServiceCommand(int Id) : IRequest<Result<Unit>>; 