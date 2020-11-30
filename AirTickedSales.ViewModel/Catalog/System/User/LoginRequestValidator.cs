using FluentValidation;

namespace AirTickedSales.ViewModel.Catalog.System.User
{
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("PassWord is required").MinimumLength(6).WithMessage("Password is at least 6 characters");
        }
    }
}
