using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItemSale
{
    public class CancelItemSaleCommand : IRequest<CancelItemSaleResponse>
    {
        public Guid SaleId { get; }
        public Guid ItemId { get; }
        public CancelItemSaleCommand(Guid saleId, Guid itemId)
        {
            SaleId = saleId;
            ItemId = itemId;
        }
    }
}
   