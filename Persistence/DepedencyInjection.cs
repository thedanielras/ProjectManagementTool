using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ProjectManagementToolDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProjectManagementToolConnection")));
            services.AddScoped<IProjectManagementToolDbContext>(provider => provider.GetRequiredService<ProjectManagementToolDbContext>());
            services.AddScoped<IProjectRepository, SqlProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}
