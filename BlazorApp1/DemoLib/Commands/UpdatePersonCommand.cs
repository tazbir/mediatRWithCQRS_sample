using DemoLib.DataAccess.Models;
using MediatR;

namespace DemoLib.Commands;

public record UpdatePersonCommand(Guid Id, string FirstName, string LastName) : IRequest<PersonModel>;