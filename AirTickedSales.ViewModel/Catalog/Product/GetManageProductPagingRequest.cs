using AirTickedSales.ViewModel.Catalog.Common;
using System.Collections.Generic;

namespace AirTickedSales.ViewModel.Catalog.Product
{
    public class GetManageProductPagingRequest : PagedResultBase
    {
        public string keyWord { get; set; }

        public List<int> CategoryIds { get; set; }

    }
}
