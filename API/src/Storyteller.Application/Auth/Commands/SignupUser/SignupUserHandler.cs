using MediatR;
using Storyteller.Application.Validation;

namespace Storyteller.Application.Auth.Commands.SignupUser
{
    public class SignupUserHandler : IRequestHandler<SignupUserRequest, HandlerResultEmpty>
    {
        public async Task<HandlerResultEmpty> Handle(SignupUserRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(10);
            throw new ArgumentNullException("ex");
            return HandlerResultEmpty.Success();
        }
    }
}
