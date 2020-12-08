using AirTickedSales.ViewModel.Catalog.Common;

namespace AirTickedSales.ViewModel.Catalog.Product
{
    public class GetPublicProductPagingRequest : PagingdRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
