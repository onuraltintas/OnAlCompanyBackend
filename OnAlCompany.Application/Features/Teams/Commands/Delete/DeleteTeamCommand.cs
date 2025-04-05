using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Teams.Commands.Delete;

public sealed record DeleteTeamCommand(int Id) : IRequest<Result<Unit>>; 