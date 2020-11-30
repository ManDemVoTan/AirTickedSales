using AirTickedSales.ViewModel.Catalog.System;
using System.Threading.Tasks;

namespace AirTickedSales.Application.Catalog.System.User
{
    public interface IUserService
    {
        Task<string> AuthentiCate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
