using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales
{
    public class GetSalesResponse : GetSaleResponse
    {
        public IEnumerable<GetSaleResponse>? Sales { get; set; }
    }
}
