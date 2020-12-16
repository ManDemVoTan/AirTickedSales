using AirTickedSales.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.Data.Entities
{
    public class TimeKeeping
    {
        public int Id { set; get; }
        public Guid UserId { set; get; }
        public string UserCode { set; get; }
      
        public List<DataCheckTime> DataCheck { get; set; }
        public class DataCheckTime
        {
        
            public Guid Id { get; set; }
            public int Day { get; set; }
            public string TypeIn { get; set; }
            public string CheckIn { get; set; }
            public string CheckOut { get; set; }

        }
        public int Month { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public AppUser AppUser { get; set; }
    
    }
}
