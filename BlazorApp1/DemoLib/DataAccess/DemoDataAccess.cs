using DemoLib.DataAccess.Models;
using DemoLib.EventService;

namespace DemoLib.DataAccess;

public interface IDemoDataAccess
{
    List<PersonModel> GetPeople();
    PersonModel InsertPerson(string firstName, string lastName);
    PersonModel GetPeopleById(int requestId);
    PersonModel UpdatePerson(Guid requestId, string requestFirstName, string requestLastName);
}

public class DemoDataAccess : IDemoDataAccess
{
    private readonly IRepository<PersonModel> _eventRepository;
    private readonly List<PersonModel> _people = new();

    public DemoDataAccess(IRepository<PersonModel> eventRepository)
    {
        _eventRepository = eventRepository;
        var user1 = new PersonModel("Tazbir", "Bhuiyan");
        _people.Add(user1);
        _eventRepository.Save(user1, -1);
        var user2 = new PersonModel("Sufian", "Saori");
        _people.Add(user2);
        _eventRepository.Save(user2, -1);
    }

    public List<PersonModel> GetPeople()
    {
        return _people;
    }

    public PersonModel InsertPerson(string firstName, string lastName)
    {
        var model = new PersonModel(firstName, lastName);
        _people.Add(model);
        _eventRepository.Save(model, -1);
        return model;
    }
    
    public PersonModel UpdatePerson(Guid id, string firstName, string lastName)
    {
        var result = _people.FirstOrDefault(x => x.Id == id);
        result.FirstName = firstName;
        result.LastName = lastName;
        var eventObj = _eventRepository.GetById(id);
        result.UpdateChanges();
        _eventRepository.Save(result, result.Version);
        return result;
    }

    public PersonModel GetPeopleById(int requestId)
    {
        throw new NotImplementedException();
        // return _people.FirstOrDefault(x => x.Id == requestId);
    }
}