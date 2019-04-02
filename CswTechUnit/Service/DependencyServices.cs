using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Services;
using Infra;

namespace Service
{
    public class DependencyServices
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
          
            services.AddTransient<CswContext, CswContext>();
        }
    }
}
