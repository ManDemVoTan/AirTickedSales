using AirTickedSales.ViewModel.Catalog.System.User;
using System.Threading.Tasks;

namespace AirTickedSales.WebAdminApp.Services
{
   public  interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
