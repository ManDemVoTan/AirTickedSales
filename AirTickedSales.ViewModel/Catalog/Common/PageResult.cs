using System.Collections.Generic;

namespace AirTickedSales.ViewModel.Catalog.Common
{
    public class PageResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
