using FluentValidation;

namespace Storyteller.Application.Auth.Commands.SignupUser
{
    public class SignupUserRequestValidator : AbstractValidator<SignupUserRequest>
    {
        public SignupUserRequestValidator()
        {
            RuleFor(x => x.Poc).NotEmpty();
        }
    }
}
