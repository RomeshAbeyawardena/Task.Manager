using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMan.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services.Scan(scan => scan.FromAssemblyOf<ServiceRegistration>()
            .AddClasses(a => a.Where(t => t.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        }
    }
}
