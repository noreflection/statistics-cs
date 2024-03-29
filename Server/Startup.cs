using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using Statistics.Server.Models;
using Statistics.Server.Models.Abstract;
using Statistics.Server.Models.Concrete;

namespace Statistics.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            //todo: move to settings
            var connection = @"Server=DESKTOP-K9M67LC\SQLEXPRESS;Database=ApplicationDatabase;Trusted_Connection=True;";
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IWorkoutRepository, WorkoutRepository>();
            services.AddTransient<IAbsWorkoutRepository, AbsWorkoutRepository>();


            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }


                
            app.UseStaticFiles();
            // this useless namespacename is added because rider has some issues with that
            app.UseClientSideBlazorFiles<Statistics.Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // this useless namespacename is added because rider has some issues with that
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Statistics.Client.Startup>("index.html");
            });
            
        }
    }
}
