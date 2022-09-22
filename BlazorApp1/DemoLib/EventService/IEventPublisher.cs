namespace DemoLib.EventService;

public interface IEventPublisher
{
    void Publish<T>(T @event) where T : Event;
}