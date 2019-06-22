using CursoUnitTesting.API.Services;
using CursoUnitTesting.API.Services.Interfaces;
using CursoUnitTesting.Business;
using CursoUnitTesting.Business.Interfaces;
using CursoUnitTesting.Business.SQLDataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CursoUnitTesting.API
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
            services.AddMvc();
            services.AddOptions();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ISQLDataContext, SQLDataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
