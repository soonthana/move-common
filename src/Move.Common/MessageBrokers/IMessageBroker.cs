namespace Move.Common.MessageBrokers;

public interface IMessageBroker
{
    Task PublishAsync(string message);
    Task PublishAsync(object message);
}