using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public DateTime Date { get; set; }
    public string? Customer { get; set; }
    public string? Branch { get; set; }
    public List<CreateSaleItemCommand>? Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }

    public class CreateSaleItemCommand
    {
        public string? Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool IsCancelled { get; set; }
    }
}