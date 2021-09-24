using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCSharpWithSelenium.Tests
{
    public class BaseTest
    {
        protected IConfiguration _configuration;
        public BaseTest()
        {
            //Como estava configurado na vídeo-aula
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // requires Microsoft.Extensions.Configuration.Json
                .AddJsonFile(@"Configurations\appsettings.json"); // requires Microsoft.Extensions.Configuration.Json


            _configuration = builder.Build();

            //OUTRO EXEMPLO ENCONTRADO:
            //var config = new ConfigurationBuilder().AddJsonFile(@"Configurations\sqlserver.json", false).Build();

            //var sqlserver = config.GetConnectionString("SqlServerConnection");
            //var mysql = config.GetConnectionString("MySqlConnection");
            //var firebase = config.GetConnectionString("FirebaseConnection");
            //var azure = config.GetConnectionString("AzureConnection");
        }
    }
}
