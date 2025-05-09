using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.CancelItemSale;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelItemSaleHandler : IRequestHandler<CancelItemSaleCommand, CancelItemSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly CancelItemSaleNotification _notificationCancelled;
        private readonly ILogger<CancelItemSaleHandler> _logger;
        private readonly string Handler = nameof(CancelItemSaleHandler);
        public CancelItemSaleHandler(ISaleRepository saleRepository, CancelItemSaleNotification notificationCancelled, ILogger<CancelItemSaleHandler> logger )
        {
            _saleRepository = saleRepository;
            _notificationCancelled = notificationCancelled;
            _logger = logger;
        }
        public async Task<CancelItemSaleResponse> Handle(CancelItemSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CancelItemSaleValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);

                var success = await _saleRepository.CancelItemAsync(request.SaleId, request.ItemId, cancellationToken);
                var sale = await _saleRepository.GetByIdAsync(request.SaleId) ?? throw new Exception("Resource (Sale) Not Found");

                if (!success)
                {
                    _logger.LogInformation($"{Handler} - Item of Sale {request.SaleId} and with ID {request.ItemId} not found.", Handler);
                    throw new KeyNotFoundException($"Item of Sale {request.SaleId} and with ID {request.ItemId} not found");
                }
                var notify = _notificationCancelled.Notification(new SaleItemCancelled(sale));
                _logger.LogInformation($"[{Handler}] - {notify}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Handler} - Error occurred during sale item cancelled.", Handler);
                throw new Exception(ex.Message);
            }
            _logger.LogInformation("{Handler} - Sale Item cancelled finish with success.", Handler);
            return new CancelItemSaleResponse { Success = true };
        }
    }
}
