using AirTickedSales.ViewModel.Catalog.Common;
using AirTickedSales.ViewModel.Catalog.System.User;
using System.Threading.Tasks;

namespace AirTickedSales.Application.Catalog.System.User
{
    public interface IUserService
    {
        Task<string> AuthentiCate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<PageResult<UserVm>> GetUserPaging(GetUserPagingRequets requets);
    }
}
