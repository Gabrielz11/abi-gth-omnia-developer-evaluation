using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.Branch).NotEmpty().WithMessage("Branch cannot be empty.");
            RuleFor(sale => sale.Customer).NotEmpty().WithMessage("Customer cannot be empty.");
            RuleFor(sale => sale.Date).NotEmpty().WithMessage("Date cannot be empty.");
            RuleFor(sale => sale.Items).NotEmpty().WithMessage("Sales must have minimum 1 item.");
            RuleFor(sale => sale.TotalAmount).NotEmpty().WithMessage("Total Amount cannot be empty.");
            RuleFor(sale => sale.IsCancelled).NotEmpty().WithMessage("Cancellation flag cannot be empty.");
        }
    }
}
