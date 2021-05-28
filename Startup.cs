using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PracticalTest.Services.Todo;
using PracticalTest.Services.Employee;
using System;
using PracticalTest.Services.Persons;
using PracticalTest.Services.PersonalRecords;

[assembly: FunctionsStartup(typeof(PracticalTest.Startup))]
namespace PracticalTest
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services).BuildServiceProvider(true);
        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            var connectionString =
                Environment.GetEnvironmentVariable("SqlServerConnection");
                services.AddDbContext<ApplicationDbContext>(x =>
                {
                    x.UseSqlServer(connectionString
                    , options => options.EnableRetryOnFailure());
                });

            services.AddHttpClient();

            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPersonsService, PersonsService>();
            services.AddScoped<IPersonalRecordsService, PersonalRecordsService>();

            return services;
        }
    }
}