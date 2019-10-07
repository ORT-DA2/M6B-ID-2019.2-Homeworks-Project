using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Homeworks.DataAccess;
using Microsoft.EntityFrameworkCore;
using Homeworks.BusinessLogic;
using Homeworks.BusinessLogic.Interface;
using Homeworks.DataAccess.Interface;
using Homeworks.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Homeworks.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DbContext, HomeworksContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("HomeworksDB"))
            );
            services.AddScoped<ILogic<User>, UserLogic>();
            services.AddScoped<ISession<UserSession>, SessionsLogic>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<UserSession>, SessionsRepository>();
            services.AddScoped<ILogic<Homework>, HomeworkLogic>();
            services.AddScoped<IRepository<Homework>, HomeworkRepository>();

            services.AddCors(
                options => { options.AddPolicy(
                    "CorsPolicy", 
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
