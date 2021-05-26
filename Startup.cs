using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(PracticalTest.Startup))]
namespace PracticalTest
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
            ConfigureServices(builder.Services).BuildServiceProvider(true);
        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer("Data Source=DESKTOP-37BVSQ0;Initial Catalog=Company;Integrated Security=True"));

            return services;
        }
    }
}