using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ProjectManagementToolDbContext>(options => 
                                        options.UseSqlServer(configuration.GetConnectionString("ProjectManagementToolConnection")));
            services.AddScoped<IProjectManagementToolDbContext>(provider => provider.GetRequiredService<ProjectManagementToolDbContext>());
            services.AddScoped<IProjectRepository, SqlProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            return services;
        }
    }
}