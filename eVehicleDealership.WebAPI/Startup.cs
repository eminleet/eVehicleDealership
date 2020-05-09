using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eVehicleDealership.Modeli;
using eVehicleDealership.Modeli.Requests;
using eVehicleDealership.WebAPI.Database;
using eVehicleDealership.WebAPI.Helpers;
using eVehicleDealership.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace eVehicleDealership.WebAPI
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
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IKorisniciService>();
                        var userId = int.Parse(context.Principal.Identity.Name);

                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }

                        if (user.Uloge != null)
                        {
                            var claims = new List<Claim>();

                            foreach (var uloga in user.Uloge)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, uloga.Naziv));
                            }

                            var appIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                            context.Principal.AddIdentity(appIdentity);
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(x => x.Filters.Add<ErrorFilter>());

            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IVozilaService, VozilaService>();
            services.AddScoped<IService<Modeli.Drzava, object>, BaseService<Modeli.Drzava, object, Drzava>>();
            services.AddScoped<GradoviService>();
            services.AddScoped<ICRUDService<Modeli.Model, ModelSearchRequest, ModelInsertRequest, Modeli.Model>, ModeliService>();
            services.AddScoped<IService<Modeli.Vozilo, object>, BaseService<Modeli.Vozilo, object, Vozilo>>();
            services.AddScoped<IService<Modeli.Uloga, UlogaSearchRequest>, UlogeService>();
            services.AddScoped<IService<Modeli.Kategorija, object>, BaseService<Modeli.Kategorija, object, Kategorija>>();
            services.AddScoped<ICRUDService<Modeli.Proizvodjac, ProizvodjacSearchRequest, ProizvodjacUpsertRequest, ProizvodjacUpsertRequest>, ProizvodjaciService>();
            services.AddScoped<SlikeVozilaService>();
            services.AddScoped<OcjeneService>();

            var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Pa55w0rd2020";
            var database = Configuration["Database"] ?? "170073";

            services.AddDbContext<eVehicleDealershipContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database}; User ID={user};Password={password}"));

            //services.AddDbContext<eVehicleDealershipContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("eVehicleDealershipDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DefaultFilesOptions DefaultFile = new DefaultFilesOptions();
            DefaultFile.DefaultFileNames.Clear();
            DefaultFile.DefaultFileNames.Add("Index.html");
            app.UseDefaultFiles(DefaultFile);
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.PrepPopulation(app);
        }
    }
}
