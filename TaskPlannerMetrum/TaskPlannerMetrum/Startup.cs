using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskPlannerMetrum.Business.Implementations;
using TaskPlannerMetrum.Business;
using TaskPlannerMetrum.Model.Context;
using TaskPlannerMetrum.Repository.Generic;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using Serilog;
using TaskPlannerMetrum.Repository.Projects;

namespace TaskPlannerMetrum
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            services.AddControllers();
            //var connection = Configuration["MySQLConnection:MySQLConnectionString"];
           // services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));

            var connection = Configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connection));

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters();
            services.AddApiVersioning();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Task Planner Metrum API",
                        Version = "v1",
                        Description = "API RESTful developed for Task Planner Metrum'",
                        Contact = new OpenApiContact
                        {
                            Name = "Augusto Morais",
                            Url = new Uri("https://github.com/augustomemt")
                        }
                    });
            });
            services.AddScoped<IUserBusiness, UserBusinessImplementation>();
            services.AddScoped<IDepartmentBusiness, DepartmentBusinessImplementation>();
            services.AddScoped<IProjectsBusiness, ProjectsBusinessImplementation>();
            services.AddScoped<IClientsBusiness, ClientsBusinessImplementation>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "API RESTful developed for Task Planner Metrum - v1");
            });

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
