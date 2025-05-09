namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesNoItemResult
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string? Customer { get; set; }

        public string? Branch { get; set; }

        public decimal TotalAmount { get; set; }

        public bool IsCancelled { get; set; }
    }
}
