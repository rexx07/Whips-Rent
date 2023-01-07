using System.Text;
using Mb.Application.Common.Interfaces;
using Mb.Infrastructure.Files;
using Mb.Infrastructure.Identity;
using Mb.Infrastructure.Persistence;
using Mb.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using HttpClientHandler = Mb.Infrastructure.Services.Handlers.HttpClientHandler;

namespace Mb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var provider = configuration.GetValue("DbProvider", "Npgsql");
        var migrationAssembly = $"Mb.Infrastructure.{provider}";
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection_Postgres"),
                b =>
                {
                    b.MigrationsAssembly(migrationAssembly);
                }));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
        services.AddHttpClient("movie-base-api", c =>
        {
            c.BaseAddress = new Uri(configuration.GetSection("MovieBaseApi:Url").Value ?? string.Empty);
            c.DefaultRequestHeaders.Add(configuration.GetSection("MovieBaseApi:Key:Key").Value ?? string.Empty,
                configuration
                    .GetSection("MovieBaseApi:Key:Value").Value);
            c.DefaultRequestHeaders.Add(configuration.GetSection("MovieBaseApi:Host:Key").Value ?? string.Empty,
                configuration
                    .GetSection("MovieBaseApi:Host:Value").Value);
        });

        services.AddTransient<IHttpClientHandler, HttpClientHandler>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        services.AddTransient<ITokenService, TokenService>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]
                        ?? string.Empty))
                };
            })
            .AddIdentityServerJwt();

        return services;
    }
}