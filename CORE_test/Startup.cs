using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CORE_test.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CORE_test.Data;
using CORE_test.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CORE_test.Services;

namespace CORE_test
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
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));
      services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<ApplicationDbContext>();

      services.AddCors(o =>
        {
          o.AddPolicy("CorsPolicy", 
            builder => builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()

              );
        }
      );

      services.AddAutoMapper(typeof(Maps));

      services.AddSwaggerGen(x =>
        {
          x.SwaggerDoc("v1", 
            new OpenApiInfo
            {
              Title = "PatAPI", 
              Version = "v1",
              Description = "Permier API"
            });

          var xFile = $@"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
          string xPath = Path.Combine(AppContext.BaseDirectory, xFile);
          x.IncludeXmlComments(xPath);

        }
      );

      services.AddSingleton<ILoggerService, LoggerService>();

      //services.AddRazorPages();
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseSwagger();
      app.UseSwaggerUI(x =>
        {
          x.SwaggerEndpoint("/swagger/v1/swagger.json", "PatAPI");
          x.RoutePrefix = "";
        }
        );

      app.UseCors("CorsPolicy");

      app.UseHttpsRedirection();
     // app.UseStaticFiles(); // peut etre utilise pour le styling.. il naura pas dinterface...

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        // endpoints.MapRazorPages();
        endpoints.MapControllers();
      });
    }
  }
}
