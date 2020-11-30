using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickedSales.ViewModel.Catalog.System
{
   public  class LoginRequest
    {
        public string UserName { get; set; }
        public string passWord { get; set; }

        public bool RememberMe { get; set; }
    }
}
