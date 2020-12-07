using AirTickedSales.Data.Entities;
using AirTickedSales.ViewModel.Catalog.Common;
using AirTickedSales.ViewModel.Catalog.System.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirTickedSales.Application.Catalog.System.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _roleManager = roleManager;
            _config = config;

        }
        public async Task<ApiResult<string>> AuthentiCate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;
            var result = await _singInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!result.Succeeded) return null;
            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
        {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserVm>("User Không tồn tại");
            }
            var userVm = new UserVm()
            {
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Dob = user.Dob
            };
            return new ApiSuccessResult<UserVm>(userVm);
        }


    public async Task<ApiResult<PageResult<UserVm>>> GetUserPaging(GetUserPagingRequets requets)
    {
        var query = _userManager.Users;
        if (!string.IsNullOrEmpty(requets.Keyword))
        {
            query = query.Where(x => x.UserName.Contains(requets.Keyword) || x.PhoneNumber.Contains(requets.Keyword));
        }

        int totalRow = await query.CountAsync();

        var data = await query.Skip((requets.PageIndex - 1) * requets.PageSize)
            .Take(requets.PageSize)
            .Select(x => new UserVm
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.LastName,
                UserName = x.UserName
            }).ToListAsync();
        var pageResult = new PageResult<UserVm>()
        {
            TotalRecord = totalRow,
            Items = data
        };
        return new ApiSuccessResult<PageResult<UserVm>>(pageResult);


    }

    public async Task<ApiResult<bool>> Register(RegisterRequest request)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user != null) return new ApiErrorResult<bool>("Tài khoản này đã tồn tại");
        if (await _userManager.FindByEmailAsync(request.Email) != null) return new ApiErrorResult<bool>("Email này đã tồn tại");
        user = new AppUser()
        {
            Dob = request.Dob,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            PhoneNumber = request.PhoneNUmber,
        };
        var result = await _userManager.CreateAsync(user, request.PassWord);
        if (result.Succeeded)
        {
            return new ApiSuccessResult<bool>();
        }
        return new ApiErrorResult<bool>("Đăng ký không thành công");
    }

    public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id == id))
        {
            return new ApiErrorResult<bool>("Email này đã tồn tại");
        }
        var user = await _userManager.FindByIdAsync(id.ToString());
        user.Dob = request.Dob;
        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNUmber;
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return new ApiSuccessResult<bool>();
        }
        return new ApiErrorResult<bool>("Cập nhật không thành công");
    }
}

}


