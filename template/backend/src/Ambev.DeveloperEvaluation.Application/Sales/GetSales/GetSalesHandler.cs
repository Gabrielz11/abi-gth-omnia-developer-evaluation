using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesHandler : IRequestHandler<GetSalesCommand, GetSalesResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSalesHandler> _logger;
        private readonly string objectName = nameof(GetSalesHandler);

        public GetSalesHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetSalesHandler> logger)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetSalesResult> Handle(GetSalesCommand command, CancellationToken cancellationToken)
        {
            
            var sales = await _saleRepository.GetAllAsync(command.Skip, command.Take, cancellationToken);
            var result = new GetSalesResult();

            if (sales == null)
                throw new KeyNotFoundException($"Sales not found");

            result.Sales = _mapper.Map<IEnumerable<GetSaleResult>>(sales);

           return result;
        }
    }
}
