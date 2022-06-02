using MediatR;
using Storyteller.Application.Validation;

namespace Storyteller.Application.Auth.Commands.SignupUser
{
    public class SignupUserRequest : IRequest<HandlerResult<string>>
    {
        public string Poc { get; set; }
    }
}
