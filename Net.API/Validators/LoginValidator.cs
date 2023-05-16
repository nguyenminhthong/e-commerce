using FluentValidation;
using Net.API.ViewModel.Authentication;
using Net.APICore.Validator;

namespace Net.API.Validators
{
    public class LoginValidator : BaseValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(model => model.UserName).NotEmpty().WithMessage("UserName must be not blank!");

            RuleFor(model => model.Password).NotEmpty().WithMessage("Password must be not blank!");
        }
    }
}
