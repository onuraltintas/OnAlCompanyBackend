using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Settings.Commands.Delete;

public sealed record DeleteSettingCommand(int Id) : IRequest<Result<Unit>>; 