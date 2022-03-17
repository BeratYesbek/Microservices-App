namespace CommandsService.EventProcessor
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}