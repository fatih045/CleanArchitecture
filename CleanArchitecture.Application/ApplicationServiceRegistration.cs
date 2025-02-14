
using CleanArchitecture.Application.Interfaces;

using CleanArchitecture.Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddFluentValidationAutoValidation(); // ASP.NET Core için otomatik doğrulama

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();



            //// JWT ve Authentication servisi ekleniyor
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<JwtTokenGenerator>();

            return services;




        }
    }
}
