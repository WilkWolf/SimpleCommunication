using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCommunication.Infrastructure;
using SimpleCommunication.Infrastructure.Models;
using SimpleCommunication.Infrastructure.DatabaseModels;

namespace SimpleCommunication.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IInsertCommand, InsertCommand>();
            services.AddScoped<OrderModel>();
            services.AddScoped<SPTopTenCustomerInMonth>();
            services.AddScoped<SPSumOfOrder>();
            services.AddScoped<OrderDetailsModel>();
            services.AddTransient<IStoredProcedure, StoredProcedure>();
        }
    }
}
