using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelItemSale
{
    public class CancelItemSaleValidator : AbstractValidator<CancelItemSaleCommand>
    {
        public CancelItemSaleValidator()
        {
            RuleFor(x => x.SaleId)
                .NotEmpty()
                .WithMessage("Sale ID is required");
            RuleFor(x => x.ItemId)
                .NotEmpty()
                .WithMessage("Item Sale ID is required");
        }
    }
}
