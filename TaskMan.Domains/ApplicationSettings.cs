using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace TaskMan.Domains
{
    public class ApplicationSettings
    {
        public ApplicationSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
            DefaultConnectionString = configuration.GetConnectionString("Default");
        }

        public IDictionary<string, EncryptionKey> EncryptionKeys { get; set; }
        public string DefaultConnectionString { get; set; }
    }
}
