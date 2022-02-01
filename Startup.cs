using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace Barnama {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc (option => option.EnableEndpointRouting = false).AddRazorPagesOptions (options => {

            });
         
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { Title = "Barnama Version 0.0.1", Version = "v1" });
                c.AddSecurityDefinition ("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                });
                c.AddSecurityRequirement (new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        Array.Empty<string> ()
                    }
                });
            });
            // services.AddControllers ()
            //     .AddNewtonsoftJson (options => {
            //         options.SerializerSettings.ContractResolver = new DefaultContractResolver ();
            //     });
            // services.AddControllers ().AddJsonOptions (x =>
            //     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
           services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.Configure<AppSettings> (Configuration.GetSection ("AppSettings"));
            services.AddEntityFrameworkSqlServer ();
            String connection = Configuration.GetConnectionString ("HostConnection");
            services.AddDbContext<BarnamaConntext> (options =>
                options.UseSqlServer (connection));
            string secret = Configuration["AppSettings:Secret"];
            var key = Encoding.ASCII.GetBytes (secret);
            services.AddHttpContextAccessor ();
            services.AddAuthorization (x => {
                x.AddPolicy ("hr-department", builder =>
                    builder
                    .RequireAuthenticatedUser ()
                    .RequireRole ("hr")
                );
                x.AddPolicy ("DevDepartment", builder =>
                    builder.RequireRole ("dev")
                );
            });
            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = Configuration["AppSettings:audience"],
                ValidIssuer = Configuration["AppSettings:issuer"],
                RequireSignedTokens = false,
                IssuerSigningKey =
                new SymmetricSecurityKey (Encoding.UTF8.GetBytes (secret))
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
            });
            services.AddScoped<IUserService, UserService> ();
        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");

                app.UseHsts ();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger ();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Barnama Version 0.0.1");
            });

            app.UseRouting ();
            app.UseAuthorization ();
            // global cors policy
            app.UseCors (x => x
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());
            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware> ();
            app.UseEndpoints (x => x.MapControllers ());
            app.UseMvc ();
            app.UseStaticFiles ();
            app.UseEndpoints (endpoints => {
                //endpoints.MapGraphQL ("/api");
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}