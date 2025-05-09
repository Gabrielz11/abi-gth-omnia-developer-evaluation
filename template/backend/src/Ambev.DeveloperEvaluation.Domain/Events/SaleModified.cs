using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleModified : BaseEvent
    {
        public SaleModified(Sale sale) : base(sale)
        {

        }
    }
}
