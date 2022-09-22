using DemoLib.Commands;
using DemoLib.DataAccess;
using DemoLib.DataAccess.Models;
using MediatR;

namespace DemoLib.Handlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
{
    private readonly IDemoDataAccess _data;

    public UpdatePersonHandler(IDemoDataAccess data)
    {
        _data = data;
    }
    
    public Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.UpdatePerson(request.Id,request.FirstName, request.LastName));
    }
}