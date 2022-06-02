using MediatR;
using Microsoft.AspNetCore.Mvc;
using Storyteller.Application.Auth.Commands.SignupUser;
using Storyteller.Application.Validation;

namespace Storyteller.Api.Controllers
{
    [ApiController]
    [Route("api/authorization")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<HandlerResultEmpty> Signup()
        {
            var x =  await _mediator.Send(new SignupUserRequest
            {
                Poc="adsfsdf"
            });

            return x;
        }
    }
}
