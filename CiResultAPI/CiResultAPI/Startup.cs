using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.DbContexts;
using CiResultAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CiResultAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup()
        {
            //var builder = new ConfigurationBuilder()
            //    .AddXmlFile("config.xml");
            //Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO as config property
            string connectionString = "Server=VM-VDIP15-32\\VDIVMDB;Database=TrxResultsDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ITrxResultsDbRepository, TrxResultsDbRepository>();

            services.AddDbContext<TrxResultsContext>(option => option.UseSqlServer(connectionString));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder => {
                    appBuilder.Run(async context => {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Some error on server side");
                    });
                });
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
        }
    }
}
