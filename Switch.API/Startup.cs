using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Switch.Infra.Data.Context;

namespace Switch.API
{
    public class Startup : IDesignTimeDbContextFactory<SwitchContext>
    {
        public SwitchContext CreateDbContext()
        {
            return CreateDbContext(new[] { "" });
        }
        IConfiguration Configuration { get; set; }
        public SwitchContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            Configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();

            optionsBuilder.UseLazyLoadingProxies().UseMySql(Configuration.GetConnectionString("SwitchDB"));
            return new SwitchContext(optionsBuilder.Options);
        }
    

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
