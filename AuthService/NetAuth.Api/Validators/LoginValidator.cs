using FluentValidation;
using Net.APICore.Validator;
using NetAuth.Api.Models.Request;

namespace NetAuth.Api.Validators
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
