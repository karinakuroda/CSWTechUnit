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
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IProjectAllocationService, ProjectAllocationService>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectAllocationRepository, ProjectAllocationRepository>();
            
            services.AddTransient<CswContext, CswContext>();
            
        }
    }
}
