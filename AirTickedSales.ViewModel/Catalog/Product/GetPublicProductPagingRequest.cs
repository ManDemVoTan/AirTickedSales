using AirTickedSales.ViewModel.Catalog.Common;

namespace AirTickedSales.ViewModel.Catalog.Product
{
    public class GetPublicProductPagingRequest : PagedResultBase
    {
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
