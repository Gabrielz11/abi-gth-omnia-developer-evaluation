using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        public CancelSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _saleRepository.CancelAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

            return new CancelSaleResponse { Success = true };
        }
    }
}
