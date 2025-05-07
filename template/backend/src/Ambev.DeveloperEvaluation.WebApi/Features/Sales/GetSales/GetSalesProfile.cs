using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

public class GetSalesProfile : Profile
{
    public GetSalesProfile()
    {
        CreateMap<GetSalesRequest, GetSalesCommand>()
            .ForMember(dest => dest.Skip, from => from.MapFrom(key => key.Skip ?? 0))
            .ForMember(dest => dest.Take, from => from.MapFrom(key => key.Take ?? 10));
        CreateMap<GetSalesResult, GetSalesResponse>();
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}
