using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.ViewModel.Catalog.Common
{
   public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T ResultObject { get; set; }
    }
}
