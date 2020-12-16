using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.Data.Entities
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public int? ParentId { get; set; }
        public int TypeId { get; set; }
        public int? Index { get; set; }
        public string ParentTag { get; set; }
        public string ShortName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string  Skype{ get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public string Website { get; set; }
    }
}
