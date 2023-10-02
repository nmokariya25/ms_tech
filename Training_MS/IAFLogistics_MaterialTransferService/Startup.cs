using Microsoft.EntityFrameworkCore;

namespace IAFLogistics_MaterialTransferService
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
            services.AddDbContext<MaterialTransferDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MaterialTransferServiceDatabase")));
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
