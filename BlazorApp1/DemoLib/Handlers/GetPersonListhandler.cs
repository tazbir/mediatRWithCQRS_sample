using DemoLib.DataAccess;
using DemoLib.DataAccess.Models;
using DemoLib.Queries;
using MediatR;

namespace DemoLib.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
{
    private readonly IDemoDataAccess _dataAccess;

    public GetPersonListHandler(IDemoDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.GetPeople());
    }
}