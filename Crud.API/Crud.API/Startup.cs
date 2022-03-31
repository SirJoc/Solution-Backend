using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.API.Domain.Models;
using Crud.API.Domain.Persistence.Contexts;
using Crud.API.Domain.Persistence.Repositories;
using Crud.API.Domain.Services;
using Crud.API.Exceptions;
using Crud.API.Extensions;
using Crud.API.Persistence.Repositories;
using Crud.API.Services;
using Crud.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Crud.API
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
            //Add CORS
            services.AddCors();
            services.AddControllers(o=> {
                o.Conventions.Add(new ControllerDocumentationConvention());
            });
            //AppSettings Section injection
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            //services.AddScoped<IClothRepository, ClothRepository>();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(Startup).Assembly);
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IClothRepository, ClothRepository>();
            
            services.AddScoped<IClothService, ClothService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //CORS Configuration
            app.UseCors(x => x.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlerMiddleware>(); 
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}