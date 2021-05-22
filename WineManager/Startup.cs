using WineManager.DAL;
using WineManager.DAL.Interfaces;
using WineManager.DAL.Domains;
using WineManager.DAL.Services;
using WineManager.BLL;
using WineManager.BLL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.IO;
using System;

namespace WineManager
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
         services.AddSwaggerGen(opt => 
                        {
                           var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                           var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                           opt.IncludeXmlComments(xmlPath);
                        });
         services.AddDbContext<EntityContext>(opt => opt.UseInMemoryDatabase("WineManager"));        

         services.AddTransient<IWineBottleService, WineBottleService>();
         services.AddTransient<IWineMakerService, WineMakerService>();

         services.AddTransient<IWineBottleBLL, WineBottleBLL>();
         services.AddTransient<IWineMakerBLL, WineMakerBLL>();

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseSwagger();

         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wine Manager V1");            
         });

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
         
      }
   }
}
