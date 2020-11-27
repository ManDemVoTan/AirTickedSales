using System.Collections.Generic;

namespace AirTickedSales.ViewModel.Catalog.Common
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
