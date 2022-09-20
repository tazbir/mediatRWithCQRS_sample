using DemoLib.Commands;
using DemoLib.DataAccess;
using DemoLib.DataAccess.Models;
using MediatR;

namespace DemoLib.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
{
    private readonly IDemoDataAccess _data;

    public InsertPersonHandler(IDemoDataAccess data)
    {
        _data = data;
    }
    
    public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
    }
}
