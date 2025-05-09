using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent : BaseEvent
    {
        public SaleCreatedEvent(Sale sale) : base(sale)
        {

        }
    }
}
