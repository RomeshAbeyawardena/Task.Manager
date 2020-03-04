using DNI.Shared.Contracts;
using DNI.Shared.Contracts.Options;
using DNI.Shared.Contracts.Providers;
using DNI.Shared.Services.Extensions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Domains;
using TaskMan.Domains.Constants;
using MediatR;

namespace TaskMan.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IServiceRegistrationOptions options)
        {
            services
                .AddSingleton<ApplicationSettings>()
                .RegisterCryptographicCredentialsFactory<AppCryptographicCredentials>(
                    RegisterCryptographicCredentialsFactory)
                .AddMediatR(Assembly.GetAssembly(typeof(ServiceRegistration)));

            services.Scan(scan => scan.FromAssemblyOf<ServiceRegistration>()
            .AddClasses(a => a.Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Provider")))
                .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }

        
        private void RegisterCryptographicCredentialsFactory(ISwitch<string, ICryptographicCredentials> factory, 
            ICryptographyProvider cryptographyProvider, IServiceProvider services)
        {
            var applicationSettings = services.GetRequiredService<ApplicationSettings>();

            if(!applicationSettings.EncryptionKeys
                .TryGetValue(EncryptionKeyConstants.IdentificationData, out var identificationEncryptionKey))
                throw new KeyNotFoundException();

            if(!applicationSettings.EncryptionKeys
                .TryGetValue(EncryptionKeyConstants.PersonalData, out var personalDataEncryptionKey))
                throw new KeyNotFoundException();

            if(!applicationSettings.EncryptionKeys
                .TryGetValue(EncryptionKeyConstants.Default, out var defaultDataEncryptionKey))
                throw new KeyNotFoundException();


            factory
                .CaseWhen(EncryptionKeyConstants.Default,
                    cryptographyProvider.GetCryptographicCredentials<AppCryptographicCredentials>(KeyDerivationPrf.HMACSHA512,
                    Encoding.UTF8, defaultDataEncryptionKey.Password, defaultDataEncryptionKey.Salt,
                        defaultDataEncryptionKey.Iterations, EncryptionKeyConstants.AesKeySize,
                        Convert.FromBase64String(defaultDataEncryptionKey.InitialVector)))
                .CaseWhen(EncryptionKeyConstants.IdentificationData, 
                    cryptographyProvider
                        .GetCryptographicCredentials<AppCryptographicCredentials>(KeyDerivationPrf.HMACSHA512, 
                            Encoding.UTF8, identificationEncryptionKey.Password, identificationEncryptionKey.Salt, 
                            identificationEncryptionKey.Iterations, EncryptionKeyConstants.AesKeySize, 
                            Convert.FromBase64String(identificationEncryptionKey.InitialVector)))
                .CaseWhen(EncryptionKeyConstants.PersonalData, 
                    cryptographyProvider
                        .GetCryptographicCredentials<AppCryptographicCredentials>(KeyDerivationPrf.HMACSHA512, 
                            Encoding.UTF8, personalDataEncryptionKey.Password, personalDataEncryptionKey.Salt, 
                            personalDataEncryptionKey.Iterations, EncryptionKeyConstants.AesKeySize, 
                            Convert.FromBase64String(personalDataEncryptionKey.InitialVector)));
        }
    
    }
}
