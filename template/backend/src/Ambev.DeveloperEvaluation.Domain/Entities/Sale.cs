namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new();
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }

    }

}
