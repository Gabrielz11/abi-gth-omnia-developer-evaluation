
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public static class SaleValidation
    {
        public static void CalculateTotalAmount(this Sale sale)
        {
            sale.TotalAmount = sale.Items.Sum(item => CalculaTotalItem(item));
        }

        private static decimal CalculaTotalItem(SaleItem saleItem)
        {
            var discountItem = GetDiscount(saleItem.Quantity);
            saleItem.Discount = discountItem * 100;
            return saleItem.Quantity * saleItem.UnitPrice * (1 - discountItem);
        }

        private static decimal GetDiscount(int quantity)
        {
            if (quantity >= 4 && quantity < 10)
                return 0.10m;
            if (quantity >= 10 && quantity <= 20)
                return 0.20m;
            return 0.0m;
        }
    }
}
