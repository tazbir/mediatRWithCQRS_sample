namespace DemoLib.EventService;

public class PersonCreated : Event
{
    public readonly Guid Id;
    public readonly string FirstName;
    public readonly string LastName;

    public PersonCreated(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}

public class PersonUpdated : Event
{
    public readonly Guid Id;
    public readonly string FirstName;
    public readonly string LastName;

    public PersonUpdated(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}