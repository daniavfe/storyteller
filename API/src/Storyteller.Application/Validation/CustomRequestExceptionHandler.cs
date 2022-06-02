using MediatR;
using MediatR.Pipeline;

namespace Storyteller.Application.Validation
{
    public class CustomRequestExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TRequest: IRequest<TResponse>
        where TResponse : HandlerResult, new()
        where TException : Exception
    {

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var response = new TResponse
            {
                Error = new HandlerError
                {
                    Code = typeof(TException).ToString(),
                    Message = exception.Message
                }
            };

            state.SetHandled(response);

            return Task.CompletedTask;
        }
    }
}
