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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Data.Interfaces;
using BackEnd.Data.Services;
using Newtonsoft.Json;

namespace BackEnd
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEnd", Version = "v1" });
            });

            services.AddDbContext<DataContext>(
                opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("ConexaoBaseDados")
                )
            );

            services.AddScoped<IRepositorio, Repositorio>();
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
            services.AddScoped<IDisciplinaRepositorio, DisciplinaRepositorio>();

            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling = 
                            ReferenceLoopHandling.Ignore
                    );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
