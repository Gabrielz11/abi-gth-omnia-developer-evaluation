using static Ambev.DeveloperEvaluation.Application.Sales.CreateSale.CreateSaleCommand;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public List<CreateSaleItemCommand>? Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}
