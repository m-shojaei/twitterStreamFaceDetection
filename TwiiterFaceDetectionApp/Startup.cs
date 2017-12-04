using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using System.Timers;
using ServiceLayer;
using FluentScheduler;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Sockets;
using Newtonsoft.Json;
using TwiiterFaceDetectionApp.Controllers;
using Hangfire;
using Hangfire.MemoryStorage;

namespace TwiiterFaceDetectionApp
{
    public class Startup
    {
        //private readonly Timer timer = new Timer(10000);
        //private ServiceProvider serviceProvider;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddDbContext<TwitsDataContext>(op =>
            {
                var constring = Configuration.GetConnectionString("twittsCon");
                op.UseSqlServer(constring);
            });

            services.AddTransient<TwitterApiService>();
            services.AddTransient<TwittImageService>();
            services.AddTransient<TwittsDataProvider>();
            services.AddTransient<TwittService>();
            services.AddTransient<TwittsImageDataProvider>();
            services.AddTransient<FaceDetectionApiService>();
            services.AddSingleton<HubManager>();
            services.AddSignalR();

            services.AddHangfire(c => c.UseMemoryStorage());

            //serviceProvider = services.BuildServiceProvider();

           

            //Task.Factory.StartNew(() => serviceProvider.GetService<TwitterApiService>().checkForPhotosInTwitsByText("radiohead"));
            //Task.Factory.StartNew(() =>
            //{
            //    timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
            //    timer.AutoReset = false;
            //    timer.Start();
            //});


        }


        public void OnTimerElapsed()
        {
            //serviceProvider.GetService<HubManager>().InvokeAsync("Send", "RecurringJob");

            //var res = serviceProvider.GetService<TwittImageService>().DetectFacesIntoredTwittsImages().Result;

            //if (res.Count > 0)
            //{
            //    res.Reverse();
            //    var aa = JsonConvert.SerializeObject(res.Take(10));
            //    serviceProvider.GetService<HubManager>().InvokeAsync("Send", aa);
            //}

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseHangfireServer();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("chat");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //var jobId = BackgroundJob.Enqueue(
            //() => serviceProvider.GetService<TwitterApiService>().checkForPhotosInTwitsByText("radiohead"));
            //RecurringJob.AddOrUpdate(
            //     () => OnTimerElapsed(),
            //     Cron.Minutely());
        }

    }
}
