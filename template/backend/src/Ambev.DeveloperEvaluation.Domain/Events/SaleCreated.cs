using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreated : BaseEvent
    {
        public SaleCreated(Sale sale) : base(sale)
        {

        }
    }
}
