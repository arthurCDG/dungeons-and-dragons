using dnd_infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dungeons_and_dragons;

public class Program
{
    public static void Main(string[] args)
    {
        var ALLOW_DEV_FRONT_END = "_allowDevFrontEnd";

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: ALLOW_DEV_FRONT_END,
                policy => {
                    policy.WithOrigins("http://localhost:4200");
                }
            );
        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Scope services from other Bounded Contexts
        builder.Services.AddInfraExtensiosn();
        builder.Services.AddDomainExtensions();
        builder.Services.AddServicesExtensions();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors(ALLOW_DEV_FRONT_END);
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}