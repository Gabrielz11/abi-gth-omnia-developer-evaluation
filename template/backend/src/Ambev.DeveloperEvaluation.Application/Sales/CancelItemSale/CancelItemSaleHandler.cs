using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.CancelItemSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelItemSaleHandler : IRequestHandler<CancelItemSaleCommand, CancelItemSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        public CancelItemSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task<CancelItemSaleResponse> Handle(CancelItemSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelItemSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _saleRepository.CancelItemAsync(request.SaleId,request.ItemId, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Item of Sale {request.SaleId} and with ID {request.ItemId} not found");

            return new CancelItemSaleResponse { Success = true };
        }
    }
}
