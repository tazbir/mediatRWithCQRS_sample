using DemoLib.EventService;

namespace DemoLib.DataAccess.Models;

public class PersonModel : AggregateRoot
{
    public string FirstName { get; set; }
    public string LastName{ get; set; }
    public override Guid Id { get; set; }


    public PersonModel()
    {
        // used to create in repository ... many ways to avoid this, eg making private constructor
    }
    public PersonModel(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Id = Guid.NewGuid();
        ApplyChange(new PersonCreated(Id, firstName, lastName));
    }

    public void UpdateChanges()
    {
        ApplyChange(new PersonUpdated(Id, FirstName, LastName));
    }

}