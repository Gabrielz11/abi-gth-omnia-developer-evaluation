using Ambev.DeveloperEvaluation.Application.Sales.CancelItemSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelItemSale
{
    public class CancelItemSaleProfile : Profile
    {
        public CancelItemSaleProfile() 
        {
            //tuplas
            CreateMap<(Guid SaleId, Guid ItemId), CancelItemSaleCommand>()
               .ConstructUsing(key => new CancelItemSaleCommand(key.SaleId,key.ItemId));
        }
    }
}
