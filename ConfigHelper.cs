using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace sqlbro
{
    class ConfigurationHelper
    {
        //contstructor
        private IConfigurationRoot configuration;
        public ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
             this.configuration = builder.Build();
        }

        public string getConfig(string handle)
        {
            string result = configuration.GetConnectionString(handle.ToUpper());
            return result;
        }
    }
}