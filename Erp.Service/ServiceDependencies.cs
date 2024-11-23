using Microsoft.Extensions.DependencyInjection;
using Name.Service.Abstracts;
using Name.Service.Implementations;

namespace Name.Service
{
    public static class ServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();


            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserBaseService, UserBaseService>();





            return services;
        }
    }
}
