namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleResult
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string? Customer { get; set; }

        public string? Branch { get; set; }

        public List<GetSaleItemResult>? Items { get; set; }

        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; }
    }

    public class GetSaleItemResult
    {
        public Guid Id { get; set; }

        public string? Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public bool IsCancelled { get; set; }
    }
}
