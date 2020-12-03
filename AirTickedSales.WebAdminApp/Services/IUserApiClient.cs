using AirTickedSales.ViewModel.Catalog.Common;
using AirTickedSales.ViewModel.Catalog.System.User;
using System.Threading.Tasks;

namespace AirTickedSales.WebAdminApp.Services
{
   public  interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<UserVm>> GetUserPagings (GetUserPagingRequets request);
        Task<bool> RegisterUser(RegisterRequest request);
    }
}
