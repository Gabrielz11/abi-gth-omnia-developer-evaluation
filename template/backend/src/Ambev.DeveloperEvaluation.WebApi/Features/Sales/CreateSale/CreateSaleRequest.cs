using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public DateTime Date { get; set; }
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public List<CreateSaleItemRequest>? Items { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}
