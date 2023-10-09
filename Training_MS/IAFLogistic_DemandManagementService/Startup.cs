using IAFLogistic_DemandManagementService.MQ;
using Microsoft.EntityFrameworkCore;

namespace IAFLogistic_DemandManagementService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DemandServiceDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DemandServiceDatabase")));
            services.AddScoped<IRabitMQProducer, RabitMQProducer>();
            services.AddSwaggerGen();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
