using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using JohnBookStore.Infrastructure.Data;
using JohnBookStore.Application.Interfaces;
using JohnBookStore.Application.Services;
using JohnBookStore.Infrastructure.IRepositories.Base;
using JohnBookStore.Infrastructure.Repositories.Base;
using JohnBookStore.Infrastructure.IRepositories;
using JohnBookStore.Infrastructure.Repositories;

namespace JohnBookStore.Api
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

            services.AddControllers();
            services.AddDbContext<JohnBookStoreContext>(
                m => m.UseSqlServer(Configuration.GetConnectionString("Default")), ServiceLifetime.Singleton);
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IStoreService, StoreService>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
