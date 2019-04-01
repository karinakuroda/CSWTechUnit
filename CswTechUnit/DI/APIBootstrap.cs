using Domain.Interface.Repository;
using Domain.Interfaces.Services;
using Infra;
using Infra.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;

namespace DI
{
    public class APIBootstrap
    {
        public static void ConfigureServices(ref IServiceCollection services)
        {
            var configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false)
                                                              .AddJsonFile("appsettings.Development.json", optional: true)
                                                              .Build();

            //New object every time
            //SERVICES
            services.AddTransient<IEmployeeService, EmployeeService>();
            //REPOS
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<CswContext, CswContext>();
            
        }
    }
}
