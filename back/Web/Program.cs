using dnd_application;
using dnd_infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace dungeons_and_dragons;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiPlayground", Version = "v1" });
                c.AddSecurityDefinition(
                    "token",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer",
                        In = ParameterLocation.Header,
                        Name = HeaderNames.Authorization
                    }
                );
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "token"
                                },
                            },
                            Array.Empty<string>()
                        }
                    }
                );
            }
        );

        // Scope services from other Bounded Contexts
        builder.Services.AddInfraExtensions();
        builder.Services.AddDomainExtensions();
        builder.Services.AddApplicationExtensions();
        builder.Services.AddWebExtensions();

        // JWT authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new()
            {
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });
        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}