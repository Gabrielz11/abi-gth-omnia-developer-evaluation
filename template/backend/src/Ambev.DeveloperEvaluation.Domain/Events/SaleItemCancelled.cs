using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleItemCancelled : BaseEvent
    {
        public SaleItemCancelled(Sale sale):base(sale) 
        {

        }
    }
}
