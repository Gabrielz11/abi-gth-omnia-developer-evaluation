using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesCommand : IRequest<GetSalesResult>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public GetSalesCommand(int? skip, int? take)
        {
            Skip = skip;
            Take = take;
        }
    }
}
