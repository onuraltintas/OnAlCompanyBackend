using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Abouts.Commands.Delete;

public sealed record DeleteAboutCommand(int Id) : IRequest<Result<Unit>>; 