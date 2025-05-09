using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly CancelSaleNotification _notificationCancelled;
        private readonly ILogger<CancelSaleHandler> _logger;
        private readonly string Handler = nameof(CancelSaleHandler);
        public CancelSaleHandler(ISaleRepository saleRepository, CancelSaleNotification notificationCancelled, ILogger<CancelSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _notificationCancelled = notificationCancelled;
            _logger = logger;
        }
        public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CancelSaleValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult.Errors);
                var sale = await _saleRepository.GetByIdAsync(request.Id) ?? throw new Exception("Resource (Sale) Not Found");
                var success = await _saleRepository.CancelAsync(request.Id, cancellationToken);

                if (!success)
                {
                    _logger.LogInformation($"{Handler} - Sale with ID {request.Id} not found.", Handler);
                    throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
                }
                var notify = _notificationCancelled.Notification(new SaleCancelled(sale));
                _logger.LogInformation($"[{Handler}] - {notify}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Handler} - Error occurred during sale cancelled.", Handler);
                throw new Exception(ex.Message);
            }
            _logger.LogInformation("{Handler} - Sale cancelled finish with success.", Handler);
            return new CancelSaleResponse { Success = true };
        }
    }
}
