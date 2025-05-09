using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Domain.Common;

public class BaseEvent
{
    public Guid Id { get; set; }

    public string Data { get; set; }

    public BaseEvent(object obj)
    {
        Id = Guid.NewGuid();
        Data = JsonSerializer.Serialize(obj);
    }
}
