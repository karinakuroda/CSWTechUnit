using Microsoft.Extensions.DependencyInjection;
using Domain.Interface.Repository;
using Infra.Repository;

namespace Infra
{
    public class DependencyRepositories
    {
        public static void ConfigureServices(ref IServiceCollection services)
        { 
            //New object every time
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectAllocationRepository, ProjectAllocationRepository>();
        }
    }
}
