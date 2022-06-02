using MediatR;
using Storyteller.Application.Validation;

namespace Storyteller.Application.Auth.Commands.SignupUser
{
    public class SignupUserHandler : IRequestHandler<SignupUserRequest, HandlerResult<string>>
    {
        public async Task<HandlerResult<string>> Handle(SignupUserRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(10);

            return HandlerResult<string>.Success("Hello");
        }
    }
}
