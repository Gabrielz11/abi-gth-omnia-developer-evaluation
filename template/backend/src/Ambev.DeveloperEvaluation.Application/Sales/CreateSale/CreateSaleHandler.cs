using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using AutoMapper;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly CreateSaleNotification _notificationSale;
        private readonly ILogger<CreateSaleHandler> _logger;
        private readonly string Handler = nameof(CreateSaleHandler);

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper,CreateSaleNotification notificationSale, ILogger<CreateSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
            _notificationSale = notificationSale;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("{Handler} - Sale creation started.", Handler);
            CreateSaleResult result = new();
           
            try
            {
                var sale = _mapper.Map<Sale>(command);
                var validator = new CreateSaleCommandValidator();
                sale.CalculateTotalAmount();
                command.TotalAmount = sale.TotalAmount;

                var validationResult = await validator.ValidateAsync(command, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _logger.Log(LogLevel.Error, "Error of Validation - All property required");
                    throw new ValidationException(validationResult.Errors);
                }
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
                result = _mapper.Map<CreateSaleResult>(await _saleRepository.CreateAsync(sale, cancellationToken));
                var notify = _notificationSale.Notification(new SaleCreated(sale));
                _logger.LogInformation($"{Handler} - {notify}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Handler} - Error occurred during sale creation.", Handler);
                throw new Exception(ex.Message);
            }
            _logger.LogInformation("{Handler} - Sale creation completed successfully.", Handler);
            return result;
        }
    }
}
