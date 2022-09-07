using FollowThePlan.Api.Data;
using FollowThePlan.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FollowThePlan.Api
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
            services.AddDbContext<Context>(
            context => context.UseNpgsql(Configuration.GetConnectionString("Default"))
            .UseSnakeCaseNamingConvention()
            );

            services.AddControllers()
                    .AddNewtonsoftJson(
                    opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPersonalRepository, PersonalRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IObjetivoRepository, ObjetivoRepository>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                    description.GroupName,
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                      Title = "FollowThePlan API",
                      Version = description.ApiVersion.ToString(),
                      TermsOfService = new Uri("htpp://termosDeUso.com"),
                      Description = "A descrição da WebAPI da FollowThePlan",
                      License = new Microsoft.OpenApi.Models.OpenApiLicense
                      {
                          Name = "FollowThePlan License",
                          Url = new Uri("http://mit.com")
                      },
                      Contact = new Microsoft.OpenApi.Models.OpenApiContact
                      {
                          Name = "Rafael Camillo",
                          Email = "rafael.camillo14@gmail.com",
                          Url = new Uri("http://followtheplan.com")
                      }
                  });
                }

                var xmlCommnetsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommnetsFile);

                 options.IncludeXmlComments(xmlCommentsFullPath);
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                            IWebHostEnvironment env,
                            IApiVersionDescriptionProvider apiProviderDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint(
                           $"/swagger/{description.GroupName}/swagger.json",
                           description.GroupName.ToUpperInvariant());
                   }
                   options.RoutePrefix = "";
               });

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

