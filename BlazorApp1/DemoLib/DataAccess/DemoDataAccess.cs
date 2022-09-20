using DemoLib.DataAccess.Models;

namespace DemoLib.DataAccess;

public interface IDemoDataAccess
{
    List<PersonModel> GetPeople();
    PersonModel InsertPerson(string firstName, string lastName);
    PersonModel GetPeopleById(int requestId);
}

public class DemoDataAccess : IDemoDataAccess
{
    private readonly List<PersonModel> _people = new();

    public DemoDataAccess()
    {
        _people.Add(new PersonModel {Id = 1, FirstName = "Tazbir", LastName = "Bhuiyan"});
        _people.Add(new PersonModel {Id = 2, FirstName = "Sufian", LastName = "Saori"});
    }

    public List<PersonModel> GetPeople()
    {
        return _people;
    }

    public PersonModel InsertPerson(string firstName, string lastName)
    {
        var model = new PersonModel
        {
            FirstName = firstName,
            LastName = lastName
        };
        model.Id = _people.Max(x => x.Id) + 1;
        _people.Add(model);
        return model;
    }

    public PersonModel GetPeopleById(int requestId)
    {
        return _people.FirstOrDefault(x => x.Id == requestId);
    }
}