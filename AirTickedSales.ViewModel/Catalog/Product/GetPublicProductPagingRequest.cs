using AirTickedSales.ViewModel.Catalog.Common;

namespace AirTickedSales.ViewModel.Catalog.Product
{
    public class GetPublicProductPagingRequest : PagedResultBase
    {
        public int? categoryId { get; set; }
    }
}
