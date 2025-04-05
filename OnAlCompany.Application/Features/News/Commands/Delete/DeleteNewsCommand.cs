using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.News.Commands.Delete;

public sealed record DeleteNewsCommand(int Id) : IRequest<Result<Unit>>; 