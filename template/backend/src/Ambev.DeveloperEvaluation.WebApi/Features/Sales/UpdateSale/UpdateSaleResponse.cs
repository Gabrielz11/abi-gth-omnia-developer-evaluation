using static Ambev.DeveloperEvaluation.Application.Sales.UpdateSale.UpdateSaleCommand;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public List<UpdateSaleItemCommand>? Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
    }
}
