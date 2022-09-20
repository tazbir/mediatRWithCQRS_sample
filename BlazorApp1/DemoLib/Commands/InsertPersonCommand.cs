using DemoLib.DataAccess.Models;
using MediatR;

namespace DemoLib.Commands;
public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;
