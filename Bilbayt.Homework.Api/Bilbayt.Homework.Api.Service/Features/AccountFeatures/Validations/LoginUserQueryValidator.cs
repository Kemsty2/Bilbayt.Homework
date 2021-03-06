using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Queries;
using FluentValidation;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Validations
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.Dto.UserName).NotEmpty().WithMessage("Please enter your username")
                .EmailAddress().WithMessage("A Valid email is required");
            RuleFor(x => x.Dto.Password)
                .NotEmpty().WithMessage("Please enter your password")
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("Minimum eight characters, at least one uppercase letter, one lowercase letter one number and one special character");
        }
    }
}