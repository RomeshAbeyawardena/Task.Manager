using DNI.Shared.Services.Abstraction;
using System;
using TaskMan.Data;
using TaskMan.Services;

namespace TaskMan.Broker
{
    public class ServiceBroker : ServiceBrokerBase
    {
        public ServiceBroker()
        {
            Assemblies = new [] { 
                DefaultAssembly, 
                GetAssembly<ServiceRegistration>(), 
                GetAssembly<DataServiceRegistration>() 
            };
        }
    }
}
