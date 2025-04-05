using MediatR;
using TS.Result;

namespace OnAlCompany.Application.Features.Contacts.Commands.Delete;

public sealed record DeleteContactCommand(int Id) : IRequest<Result<Unit>>; 