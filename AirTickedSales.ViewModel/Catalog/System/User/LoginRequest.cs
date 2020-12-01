
namespace AirTickedSales.ViewModel.Catalog.System.User
{
   public  class LoginRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}
