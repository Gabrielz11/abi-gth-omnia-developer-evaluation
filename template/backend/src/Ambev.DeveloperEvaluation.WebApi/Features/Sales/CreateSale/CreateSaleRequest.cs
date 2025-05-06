using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public DateTime Date { get; set; }
        public string? Customer { get; set; } = string.Empty;
        public string? Branch { get; set; } = string.Empty;
        public List<CreateSaleItemRequest>? Items { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}
