using AirTickedSales.ViewModel.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.ViewModel.Catalog.System.User
{
    public class GetUserPagingRequets : PagingdRequestBase
    {
        public string Keyword { get; set; }
    }
}
