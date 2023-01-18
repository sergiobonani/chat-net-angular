using Financial.Core.ViewModels;

namespace Financial.Bot.API.Interfaces
{
    public interface IMessageBroker
    {
        void Publish<T>(T message, QueueSettings messageBroker);
    }
}
