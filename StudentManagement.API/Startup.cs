using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagement.API.Services;
using StudentManagement.API.Repositories;
using StudentManagement.API.DbContexts;
using StudentManagement.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace StudentManagement.API
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
            services.AddControllers().AddJsonOptions(x => {
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Db
            services.AddDbContext<StudentMgmtContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //DI
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            //Swagger
            services.AddSwaggerGen();

            //Enable CORS Policy
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            //app.UseExceptionHandler(a => a.Run(async context =>
            //{
            //    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            //    var exception = exceptionHandlerPathFeature.Error;

            //    var result = JsonConvert.SerializeObject(new { error = exception.Message });
            //    context.Response.ContentType = "application/json";
            //    await context.Response.WriteAsync(result);
            //}));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
