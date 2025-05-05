using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSaleHandler> _logger;

        private readonly string objectName = nameof(CreateSaleHandler);
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
                var sale = _mapper.Map<Sale>(command);
                result.Id = sale.Id;
                _logger.LogInformation($"[{objectName}]");

                 result = _mapper.Map<CreateSaleResult>(await _saleRepository.CreateAsync(sale, cancellationToken));
                return result;
            }
            catch (Exception ex) 
            {
                _logger.LogError($"[{objectName}] - Error: {ex.Message}", ex);
                throw new DomainException("Deu Ruim." + ex);
            }
        }
    }
}
