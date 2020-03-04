using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using DNI.Shared.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan.Domains;
using TaskMan.Domains.Data;

namespace TaskMan.Data
{
    public class DataServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services.AddDbContextPool<TaskManDbContext>((serviceProvider, options) => options
                .UseSqlServer(serviceProvider.GetRequiredService<ApplicationSettings>().DefaultConnectionString));

            services
                .RegisterDbContextRepositories<TaskManDbContext>(ServiceLifetime.Transient,
                typeof(Project),typeof(Task),typeof(ProjectTask),
                typeof(ProjectTaskComment),typeof(TaskReference),
                typeof(ProjectTaskStatus), typeof(Status));
        }
    }
}
