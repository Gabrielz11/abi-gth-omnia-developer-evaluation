﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelItemSale
{
    public class CancelItemSaleRequest
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
    }
}
