﻿
namespace AirTickedSales.ViewModel.Catalog.System
{
   public  class LoginRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}
