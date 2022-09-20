using DemoLib.DataAccess;
using DemoLib.DataAccess.Models;
using DemoLib.Queries;
using MediatR;

namespace DemoLib.Handlers;

public class GetPersonByIdHandler: IRequestHandler<GetPersonByIdQuery, PersonModel>
{
    private readonly IMediator _mediator;
    private readonly IDemoDataAccess _dataAccess;

    public GetPersonByIdHandler(IMediator mediator, IDemoDataAccess dataAccess)
    {
        _mediator = mediator;
        _dataAccess = dataAccess;
    }
    public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        
        // if we want to use another mediator handler to get data. 
        // var results = await _mediator.Send(new GetPersonListQuery());
        // var output = results.FirstOrDefault(x => x.Id == request.id);

        return _dataAccess.GetPeopleById(request.id);
    }
}