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

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSaleHandler> _logger;
        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<UpdateSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            UpdateSaleResult result = new();
            var sale = _mapper.Map<Sale>(request);
            sale.CalculateTotalAmount();
            request.TotalAmount = sale.TotalAmount;
            var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
            result = _mapper.Map<UpdateSaleResult>(await _saleRepository.UpdateAsync(sale, cancellationToken));

            return result;
        }
    }
}
