using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoviesAPI.DataContext;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
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
            services.AddDbContext<DataBaseContext>(x => x.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));

            services.AddControllers();
            services.AddCors(); //cors
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddScoped<MoviesService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseContext dataContext)
        {
            dataContext.Database.Migrate();
            dataContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials()); // allow credentials

            //using (var client = new DataBaseContext())
            //{
            //    ////client.Database.EnsureCreated();

            //    string rawSql = @"Insert Into actors(actorname)
            //                    Select 'Tom Hanks','Tom Hanks' WHERE NOT EXISTS (Select 1 From actors Where actorname='Tom Hanks');
            //                    Insert Into actors(actorname)
            //                    Select 'Johnny Depp','Johnny Depp' WHERE NOT EXISTS (Select 1 From actors Where actorname='Johnny Depp'); ";


            //    client.Database.ExecuteSqlRaw(rawSql);
            //}

            app.UseDefaultFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}");

                ///endpoints.MapFallbackToController("Index", "Main");
            });
        }
    }
}
