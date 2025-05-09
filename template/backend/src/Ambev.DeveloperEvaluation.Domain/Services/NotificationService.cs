using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public abstract class NotificationService<T> where T : BaseEvent
    {
        public virtual string Notification(BaseEvent @event)
        {
            try
            {
                var message = JsonSerializer.Serialize(new
                {
                    Event = nameof(@event),
                    Data = JsonSerializer.Serialize(@event),
                    Timestamp = DateTime.UtcNow
                });
                Console.WriteLine(message);
                return $"Event {nameof(@event)} ID: {@event.Id}, Content {@event.Data} to Message Broker made with sucess.";
            }
            catch (Exception ex)
            {
                return $"Publishing event {nameof(@event)} ID: {@event.Id}, Content {@event.Data} returned error:{ex.Message}";
            }
        }
    }
}
