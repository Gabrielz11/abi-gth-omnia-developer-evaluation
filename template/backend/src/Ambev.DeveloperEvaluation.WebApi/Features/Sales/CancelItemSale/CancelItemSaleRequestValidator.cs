using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelItemSale
{
    public class CancelItemSaleRequestValidator : AbstractValidator<CancelItemSaleRequest>
    {
        public CancelItemSaleRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");
            RuleFor(x => x.ItemId)
                .NotEmpty()
                .WithMessage("Item Sale ID is required");
        }
    }
}
