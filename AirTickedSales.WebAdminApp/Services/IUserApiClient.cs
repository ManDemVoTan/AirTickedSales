using AirTickedSales.ViewModel.Catalog.Common;
using AirTickedSales.ViewModel.Catalog.System.User;
using System;
using System.Threading.Tasks;

namespace AirTickedSales.WebAdminApp.Services
{
   public  interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PageResult<UserVm>>> GetUserPagings (GetUserPagingRequets request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<UserVm>> GetById(Guid id);
    }
}
