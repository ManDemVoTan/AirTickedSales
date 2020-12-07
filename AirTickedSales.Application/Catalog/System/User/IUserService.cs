using AirTickedSales.ViewModel.Catalog.Common;
using AirTickedSales.ViewModel.Catalog.System.User;
using System;
using System.Threading.Tasks;

namespace AirTickedSales.Application.Catalog.System.User
{
    public interface IUserService
    {
        Task<ApiResult<string>> AuthentiCate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);
        
        Task<ApiResult<PageResult<UserVm>>> GetUserPaging(GetUserPagingRequets requets);
        Task<ApiResult<UserVm>> GetById(Guid id);
    }
}
