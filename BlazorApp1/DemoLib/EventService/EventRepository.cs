namespace DemoLib.EventService;

public interface IRepository<T> where T : AggregateRoot, new()
{
    void Save(AggregateRoot aggregate, int expectedVersion);

    T GetlatestObjById(Guid id);
    T UpdatePreviousEntriesById(Guid id);
}


public class EventRepository<T>: IRepository<T> where T: AggregateRoot, new()
{
    private readonly IEventStore _eventStore;

    public EventRepository(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    public void Save(AggregateRoot aggregate, int expectedVersion)
    {
        _eventStore.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
    }

    public T UpdatePreviousEntriesById(Guid id)
    {
        var obj = new T(); //lots of ways to do this
        var e = _eventStore.GetEventsForAggregate(id);
        obj.LoadsFromHistory(e);
        return obj;
    }

    public T GetlatestObjById(Guid id)
    {
        var obj = new T();
        var eventObj = _eventStore.GetLatestEventObjbyId(id);
        obj.Version = eventObj.version;
        return obj;
    }
}