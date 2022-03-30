using CricketAPI.Data;
using CricketAPI.GraphQL;
using CricketAPI.GraphQL.Battings;
using CricketAPI.GraphQL.Bowlings;
using CricketAPI.GraphQL.GameLocations;
using CricketAPI.GraphQL.Games;
using CricketAPI.GraphQL.Results;
using CricketAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CricketAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenSettings = Configuration.GetSection("TokenSettings").Get<TokenSettings>();
                    
                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidIssuer = tokenSettings.Issuer,
                        ValidateIssuer = true,
                        ValidAudience = tokenSettings.Audience,
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key)),
                        ValidateIssuerSigningKey = true
                    };
                });

            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("user-policy", policy =>
                    {
                        policy.RequireRole("user");
                    }
                    );
                });

            services
                .AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(
                    Configuration.GetConnectionString("CricketConStr")
                ));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<GameType>()
                .AddType<ResultType>()
                .AddType<GameLocationType>()
                .AddType<BowlingType>()
                .AddType<BattingType>()
                .AddSorting()
                .AddAuthorization()
                .AddFiltering();

            var origins = new string[] { "http://localhost:3000" };

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api/graphql");
            });
        }
    }
}
