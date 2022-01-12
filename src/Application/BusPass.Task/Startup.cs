using BusPass.Task.Infrastructure.DI;
using BusPass.Task.Infrastructure.Hangfire;
using BusPass.Task.Interfaces;
using CoreProfiler.Web;
using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BusPass.Task
{
    public class Startup
    {
        private HangfireSettings HangfireSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region hangfire

            var hangfireSettings = new HangfireSettings();
            this.Configuration
                .GetSection("HangfireSettings")
                .Bind(hangfireSettings);
            this.HangfireSettings = hangfireSettings;

            var hangfireConnection = this.Configuration.GetConnectionString("Hangfire");
            services.AddHangfire(x =>
            {
                x.UseSqlServerStorage
                    (
                        nameOrConnectionString: hangfireConnection,
                        options: new SqlServerStorageOptions
                        {
                            SchemaName = hangfireSettings.SchemaName,
                            PrepareSchemaIfNecessary = hangfireSettings.PrepareSchemaIfNecessary,
                            JobExpirationCheckInterval = TimeSpan.FromSeconds(60)
                        }
                    )
                    .UseConsole()
                    .UseDashboardMetric(SqlServerStorage.ActiveConnections)
                    .UseDashboardMetric(SqlServerStorage.TotalConnections)
                    .UseDashboardMetric(DashboardMetrics.EnqueuedAndQueueCount)
                    .UseDashboardMetric(DashboardMetrics.ProcessingCount)
                    .UseDashboardMetric(DashboardMetrics.FailedCount)
                    .UseDashboardMetric(DashboardMetrics.SucceededCount);
            });

            var queues = this.HangfireSettings.Queues.Any()
               ? this.HangfireSettings.Queues
               : new[] { "default" };

            services.AddHangfireServer(options =>
            {
                options.ServerName = $"{Environment.MachineName}:{HangfireSettings.ServerName}";
                options.WorkerCount = this.HangfireSettings.WorkerCount;
                options.Queues = queues;
            });

            #endregion hangfire

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusPass.Task", Version = "v1" });

                var basePath = AppContext.BaseDirectory;
                var xmlFiles = Directory.EnumerateFiles(basePath, $"*.xml", SearchOption.TopDirectoryOnly);
                foreach (var xmlFile in xmlFiles)
                {
                    c.IncludeXmlComments(xmlFile, true);
                }
            });

            #endregion Swagger

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDependencyInjection(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusPass.Task v1"));

            app.UseCoreProfiler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard
            (
                pathMatch: "/hangfire",
                options: new DashboardOptions
                {
                    IgnoreAntiforgeryToken = true
                }
            );

            if (env.IsDevelopment())
            {
                var jobTrigger = serviceProvider.GetService<IJobTrigger>();
                jobTrigger.OnStart();
            }
        }
    }
}