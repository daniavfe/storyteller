using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storyteller.Application.Auth.Commands.SignupUser;
using Storyteller.Application.Validation;

namespace Storyteller.Api
{
    public static class ApiConfiguration
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
        {
           return services.AddMediatR(typeof(SignupUserHandler).Assembly)
                .AddValidatorsFromAssembly(typeof(SignupUserHandler).Assembly, ServiceLifetime.Scoped)
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

    }
}
