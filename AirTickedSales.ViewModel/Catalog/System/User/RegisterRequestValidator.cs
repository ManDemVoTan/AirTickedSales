using FluentValidation;
using System;

namespace AirTickedSales.ViewModel.Catalog.System.User
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required")
                .MaximumLength(200).WithMessage("Fist Name can not over 200 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required")
               .MaximumLength(200).WithMessage("Last Name can not over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birth day greater than 100 year");
            RuleFor(x => x.Email).NotEmpty().WithMessage("EMail is required").Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$").WithMessage("EMail format not match");

            RuleFor(x => x.PhoneNUmber).NotEmpty().WithMessage("Phone Number is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Pass Word is required").MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.PassWord != request.ConfirmPassWord)
                {
                    context.AddFailure("ConfirmPassWord is not match");
                }
            });
        }
    }
}
