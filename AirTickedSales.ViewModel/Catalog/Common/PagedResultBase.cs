namespace AirTickedSales.ViewModel.Catalog.Common
{
    public class PagedResultBase: RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
