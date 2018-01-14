using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIDataExample.Entities;
using DIDataExample.Repositories;
using DIDataExample.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DIDataExample
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
            services.AddDbContext<ExampleDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ExampleDbConnection"),
                    mssql => mssql.MigrationsAssembly("DIDataExample"));
            }, ServiceLifetime.Singleton);

            //services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
