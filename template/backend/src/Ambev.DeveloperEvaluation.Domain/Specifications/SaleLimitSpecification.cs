using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    public class SaleLimitSpecification : ISpecification<Sale>
    {
        public bool IsSatisfiedBy(Sale sale)
        {
            return (sale.Items.GroupBy(x => x.Product)
                   .Any(group => group.Sum(x => x.Quantity) > 20));
        }

        public bool IsSatisfiedByDiscount(Sale sale)
        {
            return (sale.Items.Any(item => item.Quantity < 4 && item.Discount > 0));
        }
    }
}
