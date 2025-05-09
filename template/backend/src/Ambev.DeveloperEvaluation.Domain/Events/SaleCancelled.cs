using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCancelled : BaseEvent
    {
        public SaleCancelled(Sale sale) : base(sale)
        {

        }
    }
}
