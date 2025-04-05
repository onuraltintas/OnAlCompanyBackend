using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Projects.Commands.Delete;

public sealed record DeleteProjectCommand(int Id) : IRequest<Result<Unit>>; 