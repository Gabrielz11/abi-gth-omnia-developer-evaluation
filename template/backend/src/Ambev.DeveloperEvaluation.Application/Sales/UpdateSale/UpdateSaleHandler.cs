using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly UpdateSaleNotification _notificationUpdate;
        private readonly ILogger<UpdateSaleHandler> _logger;
        private readonly string Handler = nameof(UpdateSaleHandler);

        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, UpdateSaleNotification notificationUpdate, ILogger<UpdateSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
            _notificationUpdate = notificationUpdate;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{Handler} - Sale updated started.", Handler);
            UpdateSaleResult result = new();
            try
            {
                var sale = _mapper.Map<Sale>(request);
                sale.CalculateTotalAmount();
                request.TotalAmount = sale.TotalAmount;

                var itemLimitSpecification = new SaleLimitSpecification();
                if (itemLimitSpecification.IsSatisfiedBy(sale))
                {
                    _logger.Log(LogLevel.Error, "Error of Domain - Limit item per product");
                    throw new DomainException("Sale exceeds item quantity limits: no more than 20 units per product are allowed.");
                }
                var itemDiscountSpecification = new SaleLimitSpecification();
                if (itemDiscountSpecification.IsSatisfiedByDiscount(sale))
                {
                    _logger.Log(LogLevel.Error, "Error of Domain - Limit item per product");
                    throw new DomainException("Cannot apply discount on items with quantity less than 4 or with fewer than 4 items.");
                }

                result = _mapper.Map<UpdateSaleResult>(await _saleRepository.UpdateAsync(sale, cancellationToken));
                var notify = _notificationUpdate.Notification(new SaleCreated(sale));
                _logger.LogInformation($"{Handler} - {notify}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Handler} - Error occurred during sale updated.", Handler);
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
