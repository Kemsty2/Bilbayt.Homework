using Bilbayt.Homework.Api.Service.Features.AccountFeatures.Commands;
using FluentValidation;

namespace Bilbayt.Homework.Api.Service.Features.AccountFeatures.Validations
{
    /// <summary>
    /// RegisterUserCommand validator using fluent validation
    /// https://stackoverflow.com/questions/19605150/regex-for-password-must-contain-at-least-eight-characters-at-least-one-number-a
    /// </summary>
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Dto.FullName).NotEmpty().WithMessage("Please enter your fullname");
            RuleFor(x => x.Dto.UserName).NotEmpty().WithMessage("Please enter your username")
                .EmailAddress().WithMessage("A Valid email is required");
            RuleFor(x => x.Dto.Password)
                .NotEmpty().WithMessage("Please enter your password")
                .Matches(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$").WithMessage("Minimum eight characters, at least one letter and one number");
        }
    }
}