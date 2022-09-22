using DemoLib.Commands;
using DemoLib.DataAccess.Models;
using DemoLib.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<List<PersonModel>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<PersonModel> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<PersonModel> Post([FromBody] PersonModel model)
        {
            var dataModel = new InsertPersonCommand(model.FirstName, model.LastName);
            return await _mediator.Send(dataModel);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<PersonModel>  Put(Guid id, [FromBody] PersonModel model)
        {
            var dataModel = new UpdatePersonCommand(id, model.FirstName, model.LastName);
            return await _mediator.Send(dataModel);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
