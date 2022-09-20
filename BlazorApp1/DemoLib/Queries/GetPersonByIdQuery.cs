using DemoLib.DataAccess.Models;
using MediatR;

namespace DemoLib.Queries;

public record GetPersonByIdQuery(int id) : IRequest<PersonModel>;


// class level implementation sample
//  public class GetPersonByIdQueryClass : IRequest<IRequest<PersonModel>>
//  {
//      public int Id { get; set; }
//
//      public GetPersonByIdQueryClass(int id)
//      {
//          Id = id;
//      }
//  }
