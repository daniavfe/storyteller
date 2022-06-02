using FluentValidation;
using MediatR;

namespace Storyteller.Application.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : HandlerResult, new()
    {

        private readonly IEnumerable<IValidator> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var validations = _validators.Select(x => x.Validate(context))
                                                .SelectMany(x => x.Errors)
                                                .Where(x => x != null)
                                                .ToList();

            var validationFailure = _validators.Select(x => x.Validate(context))
                                                .SelectMany(x => x.Errors)
                                                .Where(x => x != null)
                                                .FirstOrDefault();
            if (validationFailure != null)
            {
                var response = new TResponse
                {
                    Error = new HandlerError
                    {
                        Code = validationFailure.ErrorCode,
                        Message = validationFailure.ErrorMessage
                    }
                };

                return Task.FromResult(response);
            }

            return next();
        }

    }
}
