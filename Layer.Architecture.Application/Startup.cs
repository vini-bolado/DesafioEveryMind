using Layer.Architecture.Infra.Data.Context;
using Layer.Architeture.Configuracao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Layer.Architecture.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapperSetup();
            services.AddDependencyInjectionSetup();
            services.AddDbContext<MyContext>(options =>
            {
                var server = Configuration["database:sqlserver:server"];
                var port = Configuration["database:sqlserver:port"];
                var database = Configuration["database:sqlserver:database"];
                var username = Configuration["database:sqlserver:username"];
                var password = Configuration["database:sqlserver:password"];

                //options.UseSqlServer($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}", opt =>
                //{
                //    opt.CommandTimeout(180);
                //    opt.EnableRetryOnFailure(5);
                //});
            });
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { 
                Title="InterFood"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Interfood.Api v1"));
            app.UseSwagger();
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
