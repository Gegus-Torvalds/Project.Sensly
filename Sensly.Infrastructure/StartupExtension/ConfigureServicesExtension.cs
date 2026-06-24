using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Sensly.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Sensly.Core.Domain.RepositoryContracts;
using Sensly.Infrastructure.Repositories;
using Sensly.Core.ServiceContracts;
using Sensly.Core.Services;
using Sensly.Core.ServiceContracts.Authentication;
using Sensly.Infrastructure.Authentication;

namespace Sensly.Infrastructure.StartupExtension
{
    public static class ConfigureServicesExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>(); 

        }
    }
}
