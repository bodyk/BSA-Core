using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreTest.Data;
using CoreTest.Extensions;
using CoreTest.Logging;
using CoreTest.Services.Implementations;
using CoreTest.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreTest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddTransient<ILogger, CustomLogger>();
            services.AddTransient<LoggerService>();
            services.AddTransient<CustomLogger>();
            services.AddTransient<CustomLoggerConfiguration>();



            services.AddMvc();
            services.AddSingleton(provider => Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SchoolContext context)
        {
            loggerFactory
                .AddConsole()
                .AddDebug();

            loggerFactory.AddCustomLogger(c =>
            {
                c.LogLevel = LogLevel.Information;
                c.FilePath = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\CustomLog.txt";
            });

            DbInitializer.Initialize(context);

            app.UseMvc();

        }
    }
}
