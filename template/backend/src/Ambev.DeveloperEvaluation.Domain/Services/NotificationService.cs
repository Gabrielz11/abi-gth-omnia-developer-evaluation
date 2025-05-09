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
                    Event = @event.GetType().Name,
                    Data = JsonSerializer.Serialize(@event),
                    Timestamp = DateTime.UtcNow
                });
                Console.WriteLine(message);
                return $"Event {@event.GetType().Name} ID: {@event.Id}, Content {@event.Data} published successfully.";
            }
            catch (Exception ex)
            {
                return $"Error publishing event {@event.GetType().Name} ID: {@event.Id}, Content {@event.Data}: {ex.Message}";
            }
        }
    }
}
