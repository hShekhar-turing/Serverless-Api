using FluentValidation;

namespace UserAuthApi
{
    public class AuthenticateModelValidator : AbstractValidator<AuthenticateModel>
    {
        public AuthenticateModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
