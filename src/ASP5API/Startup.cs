using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using ASP5API.Models;
//using ASP5API.re
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;

namespace ASP5API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var connection = "Data Source=C:\\Users\\Olle\\Source\\Repos\\ASP5API\\src\\ASP5API\\dataeventrecords.sqlite"; // Configuration["Production:SqliteConnectionString"];

            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<DataEventRecordContext>(options => options.UseSqlite(connection));

            //services.AddScoped<IDataEventRecordResporitory, DataEventRecordResporitory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();

            //Lite seed
            //DataEventRecordContext db = new DataEventRecordContext();
            //db.DataEventRecords.Add(new DataEventRecord { Description = "Hej!", Id = 1, Name = "Namn!", Timestamp = DateTime.Now });
            //db.DataEventRecords.Add(new DataEventRecord { Description = "Hej igen!", Id = 2, Name = "neeeeejm!", Timestamp = DateTime.Now.AddDays(-1) });
            //db.SaveChanges();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
