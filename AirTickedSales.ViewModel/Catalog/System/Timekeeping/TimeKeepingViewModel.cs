using System;
using System.Collections.Generic;
using static AirTickedSales.Data.Entities.TimeKeeping;

namespace AirTickedSales.ViewModel.Catalog.System.Timekeeping
{
    public class TimeKeepingViewModel
    {
        public int i { get; set; }
        public long EmployeeCode { get; set; }
        public List<DataCheckTime> DateCheck { get; set; }
        public int Month { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
    }
}
