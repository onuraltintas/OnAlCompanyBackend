using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Sliders.Commands.Delete;

public sealed record DeleteSliderCommand(int Id) : IRequest<Result<Unit>>; 