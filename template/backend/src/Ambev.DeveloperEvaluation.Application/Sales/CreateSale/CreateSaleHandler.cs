using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSaleHandler> _logger;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CreateSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            CreateSaleResult result = new();
            try
            {
                var validator = new CreateSaleCommandValidator();
                var validationResult = await validator.ValidateAsync(command, cancellationToken);

                if (!validationResult.IsValid)
                {
                    _logger.Log(LogLevel.Error, "Error of Validation");
                    throw new ValidationException(validationResult.Errors);
                }

                var sale = _mapper.Map<Sale>(command);
                result = _mapper.Map<CreateSaleResult>(await _saleRepository.CreateAsync(sale, cancellationToken));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro to Create Sale.");
                throw new Exception(ex.Message);
            }
            _logger.LogInformation("Create Successful");
            return result;
        }
    }
}
